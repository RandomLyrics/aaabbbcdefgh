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
    
    public partial class Log
    {
        public long Id { get; set; }
        public long ObjectId { get; set; }
        public string ObjectType { get; set; }
        public System.DateTime Date { get; set; }
        public long LogTypeId { get; set; }
    
        public virtual LogType LogType { get; set; }
    }
}
