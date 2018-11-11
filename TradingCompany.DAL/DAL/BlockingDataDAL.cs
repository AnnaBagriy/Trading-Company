using DTO;
using System.Collections.Generic;
using TradingCompany.Database;

namespace TradingCompany.DAL
{
    public class BlockingDataDAL : CommonDAL<BlockingDataDTO, tblBlockingData>
    {
        public BlockingDataDAL()
        {
            Includes = new List<string>() { nameof(tblBlockingData.tblUser) };
        }
    }
}
