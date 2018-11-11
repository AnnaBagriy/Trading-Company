using AutoMapper;
using DTO;
using TradingCompany.Database;

namespace TradingCompany.DAL.MappingConfiguration
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<tblUser, UserDTO>()
                .ForMember(dst => dst.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth)); // For different properies namings
            CreateMap<UserDTO, tblUser>()
                .ForMember(dst => dst.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dst => dst.tblBlockingData, opt => opt.Ignore());
        }
    }
}
