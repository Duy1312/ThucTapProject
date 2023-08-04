using AutoMapper;
using System.Security.Policy;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Respositories;

namespace ThucTapQuanLyPhatTu.Repositories
{
    public class ChuaRepository : BaseRespository<Chuas>
    {
        private readonly IMapper _mapper;
        public ChuaRepository(ApiOption apiConfig, AppDbContext databaseContext, IMapper mapper) : base(apiConfig, databaseContext)
        {
            _mapper = mapper;
        }
    }
}
