using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class SalesReceiptLine
    {
        public int ReceiptId { get; set; }
        public int ReceiptLineNumber { get; set; }
        public int? SalesId { get; set; }
        public decimal? Amount { get; set; }

        public virtual SalesReceipt Receipt { get; set; }
        public virtual SalesHeader Sales { get; set; }
    }
}
