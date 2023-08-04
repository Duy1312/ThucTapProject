using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Dto;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Request;
using ThucTapQuanLyPhatTu.Services;

namespace ThucTapQuanLyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDangKyController : BaseApiController<DonDangKyController>
    {

        private readonly DonDangKyService _donDangKyService;
        public DonDangKyController(AppDbContext databaseContext, IMapper mapper, ApiOption apiConfig)
        {
            _donDangKyService = new DonDangKyService(apiConfig, databaseContext, mapper);
        }
        [HttpPost]

        [Route("GuiDonDangKy")]
        public MessageData AddDonDangKy(ThemDonDangKyRequest themDonDangKyRequest)
        {
            try
            {
                var res = _donDangKyService.ThemDonDangKy(UserId, themDonDangKyRequest );
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
    }
}
