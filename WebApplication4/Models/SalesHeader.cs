using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class SalesHeader
    {
        public SalesHeader()
        {
            SalesLine = new HashSet<SalesLine>();
            SalesReceiptLine = new HashSet<SalesReceiptLine>();
        }

        public int SalesId { get; set; }
        public string InvoiceNumber { get; set; }
        public int? ContactId { get; set; }
        public DateTime? SalesDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Payment { get; set; }
        public int? ReceiptId { get; set; }
        public int TransactionTypeId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual ICollection<SalesLine> SalesLine { get; set; }
        public virtual ICollection<SalesReceiptLine> SalesReceiptLine { get; set; }
    }
}
