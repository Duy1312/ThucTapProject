using AutoMapper;
using System.Drawing.Printing;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Repositories;
using ThucTapQuanLyPhatTu.Request;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ThucTapQuanLyPhatTu.Services
{
    public class ChuaService
    {
        private readonly ChuaRepository _chuaRepository;
        private readonly ApiOption _apiOption;
        private readonly IMapper _mapper;

        private readonly AppDbContext _databaseContext;
        public ChuaService(ApiOption apiOption, AppDbContext databaseContext, IMapper mapper)
        {
            _chuaRepository = new ChuaRepository(apiOption, databaseContext, mapper);
            _apiOption = apiOption;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public object GetListChua(int pageIndex, int pageSize)
        {
            try
            {
                var chuaList = _chuaRepository.GetAll();
                int totalItems = chuaList.Count();
                int skip = (pageIndex - 1) * pageSize;
                chuaList = chuaList.Skip(skip).Take(pageSize);

                var result = new PagedResult<Chuas>(chuaList.ToList(), pageSize, totalItems);
                return chuaList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object AddChua(int userId,ThemChuaRequest themChuaRequest)
        {
            try
            {
           
                if (string.IsNullOrEmpty(themChuaRequest.TenChua))
                {

                    throw new ValidateError(9000, "Invalid parameters: Tham số để trống");
                }

        

                if (themChuaRequest.TenChua.Length > 2000)
                {
                    throw new ValidateError(9000, "Invalid parameters: ten chua  exceeds 2000 characters");
                }
                var newChua = new Chuas()
                {
              
                    TenChua = themChuaRequest.TenChua,

                    NgayThanhLap = themChuaRequest.NgayThanhLap,
                    DiaChi = themChuaRequest.DiaChi,
                    TruTriId = themChuaRequest.TruTriId
                };
                _chuaRepository.Create(newChua);
                _chuaRepository.SaveChange();


                return newChua;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object UpdateChua(UpdateChuaRequest request)
        {
            try
            {
                var chua = _chuaRepository.GetById(request.ChuaId);
                if (chua == null)
                {
                    throw new Exception("chua Id invalid!");
                }

                var ChuaByTen = _chuaRepository.GetByCondition(row => row.TenChua == request.TenChua).Count();
                if (ChuaByTen > 0)
                {
                    throw new ValidateError(3001, "chua already exists");
                }

                chua.TenChua = request.TenChua;
                if (!string.IsNullOrEmpty(request.DiaChi))
                {
                    chua.DiaChi = request.DiaChi;
                }
                chua.NgayCapNhat = DateTime.Now;
                _chuaRepository.UpdateByEntity(chua);
                _chuaRepository.SaveChange();

                return chua;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object XoaChua(int chuaId)
        {
            try
            {
                var chua = _chuaRepository.GetById(chuaId);
                if (chua == null)
                {
                    throw new Exception("chua Id invalid");
                }

             
                _chuaRepository.DeleteByEntity(chua);
                _chuaRepository.SaveChange();

                return chua;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
