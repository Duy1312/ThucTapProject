using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Dto;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Request;
using ThucTapQuanLyPhatTu.Services;

namespace ThucTapQuanLyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminDuyetDonController : BaseApiController<AdminDuyetDonController>
    {
        private readonly DonDangKyService _donDangKyService;
        public AdminDuyetDonController(AppDbContext databaseContext, IMapper mapper, ApiOption apiConfig)
        {
            _donDangKyService = new DonDangKyService(apiConfig, databaseContext, mapper);
        }
        [HttpPost("Duyet")]
        public MessageData DuyetDon(DuyetDonDangKyRequest request)
        {
            try
            {
                var res = _donDangKyService.DuyetDonDangKy(UserId, request);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
        [HttpGet("GetList")]
        public MessageData GetListDon(int PageIndex, int PageSize )
        {
            try
            {
                var res = _donDangKyService.GetListDonDangKy(PageIndex, PageSize);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }


    }
}
