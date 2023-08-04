using AutoMapper;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Respositories;

namespace ThucTapQuanLyPhatTu.Repositories
{
    public class TokenRepository : BaseRespository<Token>
    {
        private readonly IMapper _mapper;
        public TokenRepository(ApiOption apiConfig, AppDbContext databaseContext, IMapper mapper) : base(apiConfig, databaseContext)
        {
            _mapper = mapper;
        }
    }
}
