using AutoMapper;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Respositories;

namespace ThucTapQuanLyPhatTu.Repositories
{
    public class DonDangKyRepository : BaseRespository<DonDangKy>
    {
        private readonly IMapper _mapper;
        public DonDangKyRepository(ApiOption apiConfig, AppDbContext databaseContext, IMapper mapper) : base(apiConfig, databaseContext)
        {
            _mapper = mapper;
        }
    }
}
