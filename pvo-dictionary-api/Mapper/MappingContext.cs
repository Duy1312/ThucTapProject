using AutoMapper;
using ThucTapQuanLyPhatTu.Dto;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Request;

namespace ThucTapQuanLyPhatTu.Mapper
{
    public class MappingContext : Profile
    {
        public MappingContext()
        {
            // user request
            CreateMap<UserRegisterRequest, PhatTu>();
            CreateMap<UserStoreRequest, PhatTu>();
        }
    }
}
