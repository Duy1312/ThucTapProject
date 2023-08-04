using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Common.Enum;
using ThucTapQuanLyPhatTu.Dto;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Request;
using ThucTapQuanLyPhatTu.Services;

namespace ThucTapQuanLyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhatTuController : BaseApiController<PhatTuController>
    {
        private readonly PhatTuService _phatTuService;
        public PhatTuController(AppDbContext databaseContext, IMapper mapper, ApiOption apiConfig)
        {
            _phatTuService = new PhatTuService(apiConfig, databaseContext, mapper);
        }

        /// <summary>
        /// Get achievement list of user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
     
        [Route("Search")]
        public MessageData SearchPhatTu(string? keyword, string? email, GioiTinh? gioiTinh, int? status, int pageIndex, int pageSize)
        {
            try
            {
                var res = _phatTuService.SearchPhatTus( keyword, email, gioiTinh, status,   pageIndex,  pageSize);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
        [HttpGet]

        [Route("GetList")]
        public MessageData GetListPhatTu(int pageIndex, int pageSize)
        {
            try
            {
                var res = _phatTuService.GetListPhatTu(pageIndex, pageSize);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
        [HttpDelete]

        [Route("Delete")]
        public MessageData DeletePhatTu(int PhatTuId)
        {
            try
            {
                var res = _phatTuService.DeletePhatTu(PhatTuId);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }

    }
}
