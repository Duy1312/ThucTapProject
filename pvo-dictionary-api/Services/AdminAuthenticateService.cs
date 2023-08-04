using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Repositories;
using ThucTapQuanLyPhatTu.Request;


namespace ThucTapQuanLyPhatTu.Services
{
    public class AdminAuthenticateService
    {
        private readonly PhatTuRepository _phatTuRepository;
        private readonly ApiOption _apiOption;
        private readonly IMapper _mapper;

        public AdminAuthenticateService(ApiOption apiOption, AppDbContext databaseContext, IMapper mapper)
        {
            _phatTuRepository = new PhatTuRepository(apiOption, databaseContext, mapper);
            _apiOption = apiOption;
            _mapper = mapper;
        }

        /// <summary>
        /// Admin login
        /// </summary>
        /// <param name="adminLoginRequest"></param>
        /// <returns></returns>
        public object AdminLogin(UserLoginRequest adminLoginRequest)
        {
            try
            {
                var admin = _phatTuRepository.UserLogin(adminLoginRequest);
                if (admin == null)
                {
                    throw new ValidateError(2000,"Username or Password incorrect");
                }
                if (admin.Role != "Admin")
                {
                    throw new ValidateError(2000, "Access denied. Only Admin users can log in.");
                }
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiOption.Secret));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var claimList = new[]
                {
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.UserData, admin.UserName),
                  new Claim(ClaimTypes.Email, admin.Email),
                new Claim(ClaimTypes.Sid, admin.PhatTuId.ToString()),
            };
                var token = new JwtSecurityToken(
                    issuer: _apiOption.ValidIssuer,
                    audience: _apiOption.ValidAudience,
                    expires: DateTime.Now.AddDays(1),
                    claims: claimList,
                    signingCredentials: credentials
                    );
                var tokenByString = new JwtSecurityTokenHandler().WriteToken(token);
                return new
                {
                    token = tokenByString,
                    role = "Admin",
                    user = admin,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object ChangeUserRole(int userId, string newRole)
        {
            try
            {
                
                if (newRole != "Admin" && newRole != "User")
                {
                    throw new Exception("Invalid role. The role must be either 'Admin' or 'User'.");
                }

   
                var user = _phatTuRepository.GetById(userId);
                if (user == null)
                {
                    throw new Exception("User not found.");
                }

        
                user.Role = newRole;

             
                _phatTuRepository.UpdateByEntity(user);
                _phatTuRepository.SaveChange();
                return newRole;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
