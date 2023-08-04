using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Dto;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Request;
using ThucTapQuanLyPhatTu.Services;

namespace ThucTapQuanLyPhatTu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminAuthenticateController : BaseApiController<AdminAuthenticateController>
    {
        private readonly AdminAuthenticateService _adminAuthenticateService;
        public AdminAuthenticateController(AppDbContext databaseContext, IMapper mapper, ApiOption apiConfig)
        {
            _adminAuthenticateService = new AdminAuthenticateService(apiConfig, databaseContext, mapper);
        }

        /// <summary>
        /// Get list schedule
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost("ChangeRole")]
        [Authorize(Roles = "Admin")]
        public MessageData ChangeRole(int userId, string newRole)
        {
            try
            {
                var res = _adminAuthenticateService.ChangeUserRole(userId, newRole);
                return new MessageData { Data = res, Status = 1, Message = "change role thanh cong" };
            }
            catch (Exception ex)
            {
                return new MessageData() { Code = "Fail", Message = ex.Message, Status = 2, ErrorCode = 1000 };
            }
        }
        [HttpPost("AdminLogin")]
        [AllowAnonymous]
        public MessageData AdminLogin(UserLoginRequest request)
        {
            try
            {
                var res = _adminAuthenticateService.AdminLogin(request);
                return new MessageData { Data = res, Status = 1, Message = "Dang nhap thanh cong" };
            }
            catch (Exception ex)
            {
                return new MessageData() { Code = "Fail", Message = ex.Message, Status = 2, ErrorCode = 1000 };
            }
        }
    }
}
