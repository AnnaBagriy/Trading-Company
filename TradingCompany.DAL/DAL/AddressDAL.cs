using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL.DAL.DALAbstractions;
using TradingCompany.Database;

namespace TradingCompany.DAL
{
    public class AddressDAL : CommonDAL<AddressDTO, tblAddress>, IAddressDAL
    {
        public AddressDAL()
        {
            Includes = new List<string>() { nameof(tblAddress.tblUser) };
        }

        public List<AddressDTO> GetByUserId(int id)
        {
            var entity = new List<AddressDTO>();

            using (var entities = new TradingCompanyEntities())
            {
                entity = _mapper.Map<List<AddressDTO>>(entities.Set<tblAddress>().Where(adr => adr.UserId == id).ToList());
            }

            if (entity == null)
            {
                throw new NullReferenceException(nameof(AddressDTO));
            }

            return entity;
        }

        public List<AddressDTO> GetByCountry(string country)
        {
            var entity = new List<AddressDTO>();

            using (var entities = new TradingCompanyEntities())
            {
                entity = _mapper.Map<List<AddressDTO>>(entities.Set<tblAddress>().Where(adr => adr.Country.ToLower() == country.ToLower()).ToList());
            }

            if (entity.Count == 0)
            {
                throw new NullReferenceException(nameof(AddressDTO));
            }

            return entity;
        }
    }
}
