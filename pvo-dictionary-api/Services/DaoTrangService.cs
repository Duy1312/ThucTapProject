using AutoMapper;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Repositories;
using ThucTapQuanLyPhatTu.Request;

namespace ThucTapQuanLyPhatTu.Services
{
    public class DaoTrangService
    {
        private readonly DaoTrangsRepository _daoTrangsRepository;
        private readonly ApiOption _apiOption;
        private readonly IMapper _mapper;
        private readonly PhatTuRepository _phatTuRepository;
        private readonly AppDbContext _databaseContext;
        public DaoTrangService(ApiOption apiOption, AppDbContext databaseContext, IMapper mapper)
        {
            _daoTrangsRepository = new DaoTrangsRepository(apiOption, databaseContext, mapper);
            _apiOption = apiOption;
            _mapper = mapper;
            _databaseContext = databaseContext;
            _phatTuRepository = new PhatTuRepository(apiOption,databaseContext,mapper);
        }
        public object GetListDaoTrangs(int pageIndex, int pageSize)
        {
            try
            {
                var daoTrangList = _daoTrangsRepository.GetAll();
                int totalItems = daoTrangList.Count();
                int skip = (pageIndex - 1) * pageSize;
                daoTrangList = daoTrangList.Skip(skip).Take(pageSize);

                var result = new PagedResult<DaoTrangs>(daoTrangList.ToList(), pageSize, totalItems);
                return daoTrangList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object AdddaoTrang(int userId, ThemDaoTrangRequest themDaoTrangRequest)
        {
            try
            {

                if (string.IsNullOrEmpty(themDaoTrangRequest.NoiDung )|| themDaoTrangRequest.NguoiChuTriId ==null || string.IsNullOrEmpty(themDaoTrangRequest.NoiToChuc)   )
                {

                    throw new ValidateError(9000, "Invalid parameters: Tham số để trống");
                }
                var TruTriCuaDaoTrang = _phatTuRepository.GetById(themDaoTrangRequest.NguoiChuTriId);
                if(TruTriCuaDaoTrang  == null )
                {
                    throw new ValidateError(3000, "Invalid id: id ko ton tai");
                } 
       
        var newDaoTrang = new DaoTrangs()
                {

            NoiToChuc = themDaoTrangRequest.NoiToChuc,
            SoThanhVienThamGia = themDaoTrangRequest.SoThanhVienThamGia,
            NguoiChuTriId = themDaoTrangRequest.NguoiChuTriId,
            ThoiGianToChuc = themDaoTrangRequest.ThoiGianToChuc,
            NoiDung = themDaoTrangRequest.NoiDung,
            DaKetThuc = themDaoTrangRequest.DaKetThuc
        };
                _daoTrangsRepository.Create(newDaoTrang);
                _daoTrangsRepository.SaveChange();


                return newDaoTrang;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object UpdateDaoTrang(UpdateDaoTrangRequest request)
        {
            try
            {
                var daoTrang = _daoTrangsRepository.GetById(request.DaoTrangId);
                if (daoTrang == null)
                {
                    throw new Exception("daoTrang Id invalid!");
                }

                daoTrang.SoThanhVienThamGia = request.SoThanhVienThamGia;
                if (!string.IsNullOrEmpty(request.NoiToChuc))
                {
                    daoTrang.NoiToChuc = request.NoiToChuc;
                }
                daoTrang.ThoiGianToChuc = request.ThoiGianToChuc;
                daoTrang.DaKetThuc = request.DaKetThuc;
                var ChuTriODaoTrang = _phatTuRepository.GetById(request.NguoiChuTriId);
                if (ChuTriODaoTrang != null || ChuTriODaoTrang.isActive == true)
                {
                    daoTrang.NguoiChuTriId = request.NguoiChuTriId;
                }
              daoTrang.NoiDung = request.NoiDung;

                _daoTrangsRepository.UpdateByEntity(daoTrang);
                _daoTrangsRepository.SaveChange();

                return daoTrang;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object XoaDaoTrang(int daoTrangId)
        {
            try
            {
                var daoTrang = _daoTrangsRepository.GetById(daoTrangId);
                if (daoTrang == null)
                {
                    throw new Exception("dao trang Id invalid");
                }


                _daoTrangsRepository.DeleteByEntity(daoTrang);
                _daoTrangsRepository.SaveChange();

                return daoTrang;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
