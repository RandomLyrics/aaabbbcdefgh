//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PromosiMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Followings
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long UserId { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}
