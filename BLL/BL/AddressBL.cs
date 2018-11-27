using BLL.Interfaces;
using BLL.Services;
using DTO;
using System.Collections.Generic;
using TradingCompany.DAL;

namespace BLL
{
    public class AddressBL : IAddressBL
    {
        AddressDAL _addressDAL;

        public AddressBL()
        {
            _addressDAL = new AddressDAL();
        }

        public IResponseData<List<AddressDTO>> GetByUserId(int id)
        {
            List<AddressDTO> addresses;
            string message = "";

            addresses = _addressDAL.GetByUserId(id);

            return new ResponseData<List<AddressDTO>>(addresses, message);
        }
    }
}
