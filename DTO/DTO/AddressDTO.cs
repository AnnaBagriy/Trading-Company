using TradingCompany.Database;

namespace DTO
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public int UserId { get; set; }

        public tblUser tblUser { get; set; }
    }
}
