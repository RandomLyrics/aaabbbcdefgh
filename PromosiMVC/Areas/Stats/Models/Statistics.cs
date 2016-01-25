using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromosiMVC.Areas.Stats.Models
{
    public class Statistics
    {
        public Company Company { get; set; }
        public long Clients { get; set; }
        public long Pushes { get; set; }
    }
}