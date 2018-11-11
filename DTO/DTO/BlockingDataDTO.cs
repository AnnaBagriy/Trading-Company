using TradingCompany.Database;

namespace DTO
{
    public class BlockingDataDTO
    {
        public int UserId { get; set; }
        public int AdminId { get; set; }
        public string Reason { get; set; }
        public int TermInHours { get; set; }
        public bool? BlockAndDelete { get; set; }

        public tblUser tblUser { get; set; }
    }
}
