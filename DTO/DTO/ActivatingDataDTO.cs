using System;
using TradingCompany.Database;

namespace DTO
{
    public class ActivatingDataDTO
    {
        public int UserId { get; set; }
        public int AdminId { get; set; }
        public DateTime ActivatingDate { get; set; }

        public tblUser tblUser { get; set; }
    }
}
