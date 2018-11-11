using System;
using System.Collections.Generic;
using TradingCompany.Database;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string KeyPasswordWord { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsFemale { get; set; }
        public string CardNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActivated { get; set; }
        public bool IsBlocked { get; set; }

        public tblActivatingData tblActivatingData { get; set; }
        public ICollection<tblAddress> tblAddresses { get; set; }
        public tblBlockingData tblBlockingData { get; set; }
    }
}
