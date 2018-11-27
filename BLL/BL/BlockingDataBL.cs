using BLL.Interfaces;
using BLL.Services;
using DTO;
using TradingCompany.DAL;

namespace BLL
{
    public class BlockingDataBL : IBlockingDataBL
    {
        private BlockingDataDAL _blockingDataDAL;

        public BlockingDataBL()
        {
            _blockingDataDAL = new BlockingDataDAL();
        }

        public IResponseData<BlockingDataDTO> GetDataByUser(UserDTO user)
        {
            if (user.tblBlockingData == null)
            {
                return null;
            }

            return new ResponseData<BlockingDataDTO>(_blockingDataDAL.GetByUserId(user.UserId), "");
        }
    }
}
