using AutoMapper;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Respositories;

namespace ThucTapQuanLyPhatTu.Repositories
{
    public class DaoTrangsRepository : BaseRespository<DaoTrangs>
    {
        private readonly IMapper _mapper;
        public DaoTrangsRepository(ApiOption apiConfig, AppDbContext databaseContext, IMapper mapper) : base(apiConfig, databaseContext)
        {
            _mapper = mapper;
        }
    }
}
