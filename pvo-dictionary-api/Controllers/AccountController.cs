using AutoMapper;
using AutoMapper.Configuration;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Controllers;
using ThucTapQuanLyPhatTu.Dto;
using ThucTapQuanLyPhatTu.Request;
using ThucTapQuanLyPhatTu.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Net.Http;
using ThucTapQuanLyPhatTu.Models;

namespace ThucTapQuanLyPhatTu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseApiController<AccountController>
    {
        private readonly AccountService _accountService;
        public AccountController(AppDbContext databaseContext, IMapper mapper, ApiOption apiConfig)
        {
            _accountService = new AccountService(apiConfig, databaseContext, mapper);
        }

        /// <summary>
        /// Get achievement list of user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public MessageData Login(UserLoginRequest userLoginRequest)
        {
            try
            {
                var res = _accountService.UserLogin(userLoginRequest);
                return new MessageData { Data = res, Status = 1, Message = "Login thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("RenewToken")]
        public MessageData RenewToken(TokenRequest tokenRequest)
        {
            try
            {
                var res = _accountService.RenewToken(tokenRequest);
                return new MessageData { Data = res, Status = 1, Message = "Renew thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
        /// <summary>
        /// account register
        /// </summary>
        /// <param name="userRegisterRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public MessageData Register(UserRegisterRequest userRegisterRequest)
        {
            try
            {
                var res = _accountService.UserRegister(userRegisterRequest);
                return new MessageData { Data = res, Status = 1, Message = "Dang ky thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }

      
      

        /// <summary>
        /// forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("forgot_password")]
        public MessageData ForgotPassword(string email)
        {
            try
            {
                var res = _accountService.ForgotPassword(email);
                return new MessageData { Data = res, Status = 1 };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }

        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("reset_password")]
        public MessageData ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            try
            {
                var res = _accountService.ResetPassword(resetPasswordRequest);
                return new MessageData { Data = res, Status = 1 };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
        [HttpPost]
        [Route("update_password")]
        public MessageData UpdatePassword(UpdatePasswordRequest updatePasswordRequest)
        {
            try
            {
                var res = _accountService.UpdatePassword(UserId,updatePasswordRequest);
                return new MessageData { Data = res, Status = 1 };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
        [HttpPost]
        [Route("update_user_info")]
        public MessageData UpdateUserInfo(UpdatePhatTuInforRequest updatePhatTuInforRequest)
        {
            try
            {
                var res = _accountService.UpdateUserInfor(UserId, updatePhatTuInforRequest);
                return new MessageData { Data = res, Status = 1 };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }

    }
}
