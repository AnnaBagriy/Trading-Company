using AutoMapper;
using DTO;
using TradingCompany.Database;

namespace TradingCompany.DAL.MappingConfiguration
{
    public class ActivatingDataProfile : Profile
    {
        public ActivatingDataProfile()
        {
            CreateMap<tblActivatingData, ActivatingDataDTO>();
            CreateMap<ActivatingDataDTO, tblActivatingData>().ForMember(dst => dst.tblUser.IsActivated, src => src.UseValue(true));
        }
    }
}
