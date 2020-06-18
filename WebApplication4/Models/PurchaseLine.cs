using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class PurchaseLine
    {
        public int PurchaseId { get; set; }
        public string PurchaseLineNumber { get; set; }
        public string PurchaseDescription { get; set; }
        public int? ItemId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Tax { get; set; }

        public virtual Item Item { get; set; }
        public virtual PurchaseHeader Purchase { get; set; }
    }
}
