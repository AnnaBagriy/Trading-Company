using AutoMapper;
using DTO;
using TradingCompany.Database;

namespace TradingCompany.DAL.MappingConfiguration
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<tblAddress, AddressDTO>();
            CreateMap<AddressDTO, tblAddress>();
        }
    }
}
