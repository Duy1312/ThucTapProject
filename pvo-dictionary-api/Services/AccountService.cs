using AutoMapper;
using AutoMapper.Configuration;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Repositories;
using ThucTapQuanLyPhatTu.Request;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Net.Mail;
using ThucTapQuanLyPhatTu.Dto;
using System.Collections;
using ThucTapQuanLyPhatTu.Entity;
using System.Drawing;
using ThucTapQuanLyPhatTu.Common.Enum;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
namespace ThucTapQuanLyPhatTu.Services
{
    public class AccountService
    {
        private readonly PhatTuRepository _phatTuRepository;
        private readonly ApiOption _apiOption;
        private readonly IMapper _mapper;
        private readonly TokenRepository _tokenRepository;

        private readonly AppDbContext _databaseContext;
        public AccountService(ApiOption apiOption, AppDbContext databaseContext, IMapper mapper)
        {
            _phatTuRepository = new PhatTuRepository(apiOption, databaseContext, mapper);
            _apiOption = apiOption;
            _mapper = mapper;
            _databaseContext = databaseContext;
            _tokenRepository = new TokenRepository(apiOption, databaseContext, mapper);
        }

        /// <summary>
        /// User login
        /// </summary>
        /// <param name="userLoginRequest"></param>
        /// <returns></returns>
        public object UserLogin(UserLoginRequest userLoginRequest)
        {
            try
            {
                var user = _phatTuRepository.UserLogin(userLoginRequest);
                if (user == null)
                {
                    throw new ValidateError(1000, "Incorrect email or password");
                }

                var token = GenerateToken(user);

                return new
                {
                    Token = token,
                    UserId = user.PhatTuId,
                    UserName = user.UserName,
                    DisplayName = user.Ten + user.TenDem + user.Ho,
                    Avatar = user.AnhChup,
                };
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private TokenRequest GenerateToken(PhatTu phatTu)
        {
   
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiOption.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claimList = new[]
            {
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.UserData, phatTu.UserName),
                new Claim(ClaimTypes.Email, phatTu.Email),
                new Claim(ClaimTypes.Sid, phatTu.PhatTuId.ToString())
            };
            var token = new JwtSecurityToken(
                     issuer: _apiOption.ValidIssuer,
                     audience: _apiOption.ValidAudience,
                     expires: DateTime.Now.AddDays(1),
                     claims: claimList,
                     signingCredentials: credentials
                 );
         
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            // Save the refresh token in the database
            var refreshTokenEntity = new Token()
            {
                Stoken = refreshToken,
                Expired = false,
                PhatTuId = phatTu.PhatTuId,
                Revoked = false,
                Token_type = TypeToken.Bearer,
                RefreshTokenExpiry = DateTime.UtcNow.AddHours(2), // Set the refresh token expiration time as needed
            };
            _tokenRepository.Create(refreshTokenEntity);
            _tokenRepository.SaveChange();
            return new TokenRequest
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
        public object RenewToken(TokenRequest model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_apiOption.Secret);
            var tokenValidateParam = new TokenValidationParameters
            {
                //tự cấp token
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = _apiOption.ValidAudience,
                ValidIssuer = _apiOption.ValidIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ValidateLifetime = false //ko kiểm tra token hết hạn
            };
            try
            {
                //check 1: AccessToken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(model.AccessToken, tokenValidateParam, out var validatedToken);
       

                //check 3: Check accessToken expire?
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    throw new ValidateError(2000, "Access token has not yet expired");
                }

                //check 4: Check refreshtoken exist in DB
                var storedToken = _databaseContext.Token.FirstOrDefault(x => x.Stoken == model.RefreshToken);
                if (storedToken == null)
                {

                    throw new ValidateError(2000, "Refresh token does not exist");
                }

                //check 5: check refreshToken is expried/revoked?
                if (storedToken.Expired)
                {
                    throw new ValidateError(2000, "Refresh token has been expired");
                }
                if (storedToken.Revoked)
                {
                    throw new ValidateError(2000, "Refresh token has been revoked");
                }



                //Update token is used
                storedToken.Expired = true;
                storedToken.Revoked = true;
                _databaseContext.Update(storedToken);
                _databaseContext.SaveChanges();

                //create new token
                var user = _phatTuRepository.GetById(storedToken.PhatTuId);

                var token = GenerateToken(user);

                return token;

            }catch (Exception ex)
            {
                throw ex;
            }
            }
        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }
        /// <summary>
        /// account/register
        /// </summary>
        /// <param name="userRegisterRequest"></param>
        /// <returns></returns>
        public object UserRegister(UserRegisterRequest userRegisterRequest)
        {
            try
            {
                var user = _phatTuRepository.GetByCondition(row => row.UserName == userRegisterRequest.username).FirstOrDefault();
                if (user != null)
                {
                    throw new ValidateError(1001, "Email has been used");
                }
                if (string.IsNullOrEmpty(userRegisterRequest.username))
                {
                    throw new ValidateError(9000, "Email is required");
                }

                // Check if password is empty
                if (string.IsNullOrEmpty(userRegisterRequest.password))
                {
                    throw new ValidateError(9000, "Password is required");
                }

                // Check email format
                if (!IsValidEmail(userRegisterRequest.username))
                {
                    throw new ValidateError(9000, "Incorrect email format");
                }

                var newUser = new PhatTu()
                {
                    UserName = userRegisterRequest.username,
                    Password = Untill.CreateMD5(userRegisterRequest.password),
                    Email = userRegisterRequest.username,
                    Role = "User"

                };
                _phatTuRepository.Create(newUser);
                _phatTuRepository.SaveChange();
                return newUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// forgot password
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string ForgotPassword(string email)
        {
            try
            {
                var user = _phatTuRepository.GetAll().Where(row => row.UserName == email).FirstOrDefault();
                if (user == null)
                {
                    throw new ValidateError(1002, "Invalid account");
                }

                var listNumber = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                var otp = "";
                Random rand = new Random();
                for (int i = 0; i < 4; i++)
                {
                    var randomNumber = rand.Next(0, 9);
                    otp += listNumber[randomNumber];
                }
                user.otp = otp;
                user.otpExpirationTime = DateTime.UtcNow.AddSeconds(15);
                _phatTuRepository.UpdateByEntity(user);
                _phatTuRepository.SaveChange();
                var expirationMessage = "Mã OTP sẽ hết hạn sau 15s Vui lòng sử dụng mã này trong thời gian này để đặt lại mật khẩu.";
                var tb = "Mã OTP Code của bạn là: " + user.otp + "het han vao luc" + expirationMessage;

                MailMessage mail = new MailMessage("shiinamashiro1312@gmail.com", user.UserName, "PVO Dictionary send OTP to reset password", tb);
                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Host = "smtp.gmail.com";
                client.UseDefaultCredentials = false;
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("shiinamashiro1312@gmail.com", "vhdccsvzwytlmmuj");
                client.EnableSsl = true;
                client.Send(mail);

                return otp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdatePassword(int userId, UpdatePasswordRequest updatePasswordRequest)
        {
            try
            {
                var user = _phatTuRepository.GetById(userId);
                if (user == null)
                {
                    throw new Exception("User does not exist in DB!");
                }

                if (user.Password != Untill.CreateMD5(updatePasswordRequest.OldPassword))
                {
                    throw new ValidateError(1000, "Incorrect email or password: Mật khẩu cũ cung cấp không đúng ");
                }

                user.Password = Untill.CreateMD5(updatePasswordRequest.NewPassword);
                _phatTuRepository.UpdateByEntity(user);
                _phatTuRepository.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="resetPasswordRequest"></param>
        /// <returns></returns>
        public bool ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            try
            {
                var user = _phatTuRepository.GetAll().Where(row => row.UserName == resetPasswordRequest.Email).FirstOrDefault();

                if (user == null)
                {
                    throw new ValidateError(9000, "Email doesn’t exist");
                }
                if (user.otpExpirationTime == null || user.otpExpirationTime < DateTime.UtcNow)
                {
                    throw new ValidateError(9000, "OTP has expired! Please request a new OTP.");
                }
                if (user.otp != resetPasswordRequest.Otp)
                {
                    throw new ValidateError(9000, "OTP invalid!");
                }

                user.Password = Untill.CreateMD5(resetPasswordRequest.NewPassword);
                user.otp = null;
                _phatTuRepository.UpdateByEntity(user);
                _phatTuRepository.SaveChange();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public object UpdateUserInfor(int userId, UpdatePhatTuInforRequest updateUserInforRequest)
        {
            try
            {
                var user = _phatTuRepository.GetById(userId);
                if (user == null)
                {
                    throw new Exception("User does not exist in DB!");
                }

                user.Ho = updateUserInforRequest.Ho;
                user.TenDem = updateUserInforRequest.TenDem;
                user.Ten = updateUserInforRequest.Ten;
                user.PhapDanh = updateUserInforRequest.PhapDanh;
                user.AnhChup = updateUserInforRequest.AnhChup;
                user.SoDienThoai = updateUserInforRequest.SoDienThoai;
                user.NgaySinh = updateUserInforRequest.NgaySinh;
                user.NgayXuatGia = updateUserInforRequest.NgayXuatGia;
                user.DaHoanTuc = updateUserInforRequest.DaHoanTuc;
                user.status = updateUserInforRequest.status;
                user.isActive = updateUserInforRequest.isActive;
                user.NgayHoanTuc = updateUserInforRequest.NgayHoanTuc;
                user.GioiTinh = updateUserInforRequest.GioiTinh;
                user.KieuThanhVienId = updateUserInforRequest.KieuThanhVienId;
                user.NgayCapNhat = DateTime.UtcNow;
                user.ChuaId = updateUserInforRequest.ChuaId;




                _phatTuRepository.UpdateByEntity(user);
                _phatTuRepository.SaveChange();
                var data = new
                {
                    Data = user,
                    DisplayName = user.UserName,
                    Status = user.status,

                };
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPassword(string password)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,16}$");
            return regex.IsMatch(password);
        }


    }
}
