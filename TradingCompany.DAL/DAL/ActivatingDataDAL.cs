using DTO;
using System.Collections.Generic;
using TradingCompany.Database;

namespace TradingCompany.DAL
{
    public class ActivatingDataDAL : CommonDAL<ActivatingDataDTO, tblActivatingData>
    {
        public ActivatingDataDAL()
        {
            Includes = new List<string>() { nameof(tblActivatingData.tblUser) };
        }
    }
}
