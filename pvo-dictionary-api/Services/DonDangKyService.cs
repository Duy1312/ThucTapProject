using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Common.Enum;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Repositories;
using ThucTapQuanLyPhatTu.Request;

namespace ThucTapQuanLyPhatTu.Services
{
    public class DonDangKyService
    {
        private readonly DonDangKyRepository _donDangKyRepository;
        private readonly DaoTrangsRepository _daoTrangsRepository;
        private readonly ApiOption _apiOption;
        private readonly IMapper _mapper;
        private readonly AppDbContext _databaseContext;
        public DonDangKyService(ApiOption apiOption, AppDbContext databaseContext, IMapper mapper)
        {
            _donDangKyRepository = new DonDangKyRepository(apiOption, databaseContext, mapper);
            _apiOption = apiOption;
            _mapper = mapper;
            _databaseContext = databaseContext;
            _daoTrangsRepository = new DaoTrangsRepository(apiOption, databaseContext, mapper);

        }
        public object GetListDonDangKy(int pageIndex, int pageSize)
        {
            try
            {
                var donDangKies = _donDangKyRepository.GetAll();
                int totalItems = donDangKies.Count();
                int skip = (pageIndex - 1) * pageSize;
                donDangKies = donDangKies.Skip(skip).Take(pageSize);

                var result = new PagedResult<DonDangKy>(donDangKies.ToList(), pageSize, totalItems);
                return donDangKies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object ThemDonDangKy(int userId, ThemDonDangKyRequest themDonDangKyRequest)
        {
            try
            {
                var daoTrang = _daoTrangsRepository.GetById(themDonDangKyRequest.DaoTrangId);
                if (daoTrang == null)
                {
                    throw new ValidateError(3001, "DaoTrang ko ton tai");
                }
                var newDonDangKy = new DonDangKy()
                {
                    PhatTuId = userId,
                    TrangThaiDon = TrangThaiDon.DANGCHO,
                    NgayGuiDon = DateTime.Now,
                 
                    DaoTrangId = themDonDangKyRequest.DaoTrangId

                };
                _donDangKyRepository.Create(newDonDangKy);
                _donDangKyRepository.SaveChange();
                return newDonDangKy;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DuyetDonDangKy(int Adminid, DuyetDonDangKyRequest duyetDonDangKyRequest)
        {
            var donDangKy = _donDangKyRepository.GetById(duyetDonDangKyRequest.DonDangKyId);
            if (donDangKy == null)
            {
                throw new ValidateError(3000, "Don dang ky ko ton tai");
            }

   
            donDangKy.TrangThaiDon = duyetDonDangKyRequest.TrangThaiDon;
            donDangKy.NgaySuLy = DateTime.UtcNow;
            donDangKy.NguoiXuLyId = Adminid;

            var daoTrangDon = _daoTrangsRepository.GetById(donDangKy.DaoTrangId);
            if (daoTrangDon == null)
            {
                throw new ValidateError(3001, "Dao trang don ko ton tai");
            }

            if (duyetDonDangKyRequest.TrangThaiDon == TrangThaiDon.DONGY)
            {
                var soThanhVienThamGiaHienTai = _donDangKyRepository
                    .GetByCondition(d => d.DaoTrangId == donDangKy.DaoTrangId && d.TrangThaiDon == TrangThaiDon.DONGY).Count();

                daoTrangDon.SoThanhVienThamGia = soThanhVienThamGiaHienTai + 1;
                _daoTrangsRepository.UpdateByEntity(daoTrangDon);
            }

         
            _donDangKyRepository.SaveChange();

            return true;
        }


    }
}
