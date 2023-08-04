using AutoMapper;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Respositories;

namespace ThucTapQuanLyPhatTu.Repositories
{
    public class PhatTuDaoTrangRepository : BaseRespository<PhatTuDaoTrang>
    {
        private readonly IMapper _mapper;
        public PhatTuDaoTrangRepository(ApiOption apiConfig, AppDbContext databaseContext, IMapper mapper) : base(apiConfig, databaseContext)
        {
            _mapper = mapper;
        }
    }
}
