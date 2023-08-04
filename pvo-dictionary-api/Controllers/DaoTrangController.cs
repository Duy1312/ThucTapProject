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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DaoTrangController : BaseApiController<DaoTrangController>
    {
        private readonly DaoTrangService _daoTrangService;
        public DaoTrangController(AppDbContext databaseContext, IMapper mapper, ApiOption apiConfig)
        {
            _daoTrangService = new DaoTrangService(apiConfig, databaseContext, mapper);
        }
        [HttpGet]

        [Route("Get")]
        public MessageData GetListDaoTrang(int pageIndex, int pageSize)
        {
            try
            {
                var res = _daoTrangService.GetListDaoTrangs(pageIndex, pageSize);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
        [HttpPost]
        [Route("Add")]
        public MessageData AdddaoTrang([FromBody] ThemDaoTrangRequest themDaoTrangRequest)
        {
            try
            {
                var res = _daoTrangService.AdddaoTrang(UserId, themDaoTrangRequest);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        public MessageData UpdateDaoTrang([FromBody] UpdateDaoTrangRequest updateDaoTrangRequest)
        {
            try
            {
                var res = _daoTrangService.UpdateDaoTrang(updateDaoTrangRequest);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public MessageData DeleteDaoTrang(int id)
        {
            try
            {
                var res = _daoTrangService.XoaDaoTrang(id);
                return new MessageData { Data = res, Status = 1, Message = "thanh cong" };
            }
            catch (Exception ex)
            {
                return NG(ex);
            }
        }
    }
}
