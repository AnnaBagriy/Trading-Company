//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradingCompany.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblActivatingData
    {
        public int UserId { get; set; }
        public int AdminId { get; set; }
        public System.DateTime ActivatingDate { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}
