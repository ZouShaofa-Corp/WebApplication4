using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class SalesReceipt
    {
        public SalesReceipt()
        {
            SalesReceiptLine = new HashSet<SalesReceiptLine>();
        }

        public int ReceiptId { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string ReceiptDescription { get; set; }
        public int AccountId { get; set; }
        public decimal? Amount { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<SalesReceiptLine> SalesReceiptLine { get; set; }
    }
}
