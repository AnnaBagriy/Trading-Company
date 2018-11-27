using BLL.Interfaces;
using BLL.Services;
using DTO;
using TradingCompany.DAL;

namespace BLL
{
    public class ActivatingDataBL : IActivatingDataBL
    {
        private ActivatingDataDAL _activatingDataDAL;

        public ActivatingDataBL()
        {
            _activatingDataDAL = new ActivatingDataDAL();
        }

        public IResponseData<ActivatingDataDTO> GetDataByUser(UserDTO user)
        {
            if (user.tblActivatingData == null)
            {
                return null;
            }

            return new ResponseData<ActivatingDataDTO>(_activatingDataDAL.GetByUserId(user.UserId), "");
        }

        public IResponse Add(ActivatingDataDTO activatingData)
        {
            _activatingDataDAL.Add(activatingData);

            return new Response("");
        }
    }
}
