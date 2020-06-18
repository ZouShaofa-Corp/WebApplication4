using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class SalesLine
    {
        public int SalesId { get; set; }
        public int SalesLineNumber { get; set; }
        public string SalesDescription { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Tax { get; set; }
        public int? AccountId { get; set; }
        public int? ItemId { get; set; }
        public decimal? Qty { get; set; }

        public virtual Account Account { get; set; }
        public virtual Item Item { get; set; }
        public virtual SalesHeader Sales { get; set; }
    }
}
