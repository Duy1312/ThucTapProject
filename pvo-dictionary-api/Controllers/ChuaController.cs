using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Common.Enum;
using ThucTapQuanLyPhatTu.Dto;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Request;
using ThucTapQuanLyPhatTu.Services;

namespace ThucTapQuanLyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChuaController : BaseApiController<ChuaController>
    {
        private readonly ChuaService _chuaService;
        public ChuaController(AppDbContext databaseContext, IMapper mapper, ApiOption apiConfig)
        {
            _chuaService = new ChuaService(apiConfig, databaseContext, mapper);
        }
        [HttpPost]
      
        [Route("Get")]
        public MessageData GetListChua( int pageIndex, int pageSize)
        {
            try
            {
                var res = _chuaService.GetListChua(pageIndex, pageSize);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
        [HttpPost]
        [Route("Add")]
        public MessageData AddChua([FromBody] ThemChuaRequest themChuaRequest)
        {
            try
            {
                var res = _chuaService.AddChua(UserId,themChuaRequest);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        public MessageData UpdateChua([FromBody] UpdateChuaRequest updateChuaRequest)
        {
            try
            {
                var res = _chuaService.UpdateChua(updateChuaRequest);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public MessageData DeleteChua(int id)
        {
            try
            {
                var res = _chuaService.XoaChua(id);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
    }
}
