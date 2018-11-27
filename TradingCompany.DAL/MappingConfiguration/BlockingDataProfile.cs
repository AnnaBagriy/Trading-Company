using AutoMapper;
using DTO;
using TradingCompany.Database;

namespace TradingCompany.DAL.MappingConfiguration
{
    public class BlockingDataProfile : Profile
    {
        public BlockingDataProfile()
        {
            CreateMap<tblBlockingData, BlockingDataDTO>();
            CreateMap<BlockingDataDTO, tblBlockingData>().ForMember(dst => dst.tblUser.IsBlocked, src => src.UseValue(true));
        }
    }
}
