using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class PurchaseHeader
    {
        public PurchaseHeader()
        {
            PurchaseLine = new HashSet<PurchaseLine>();
            PurchasePaymentLine = new HashSet<PurchasePaymentLine>();
        }

        public int PurchaseId { get; set; }
        public string InvoiceNumber { get; set; }
        public int ContactId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Payment { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual ICollection<PurchaseLine> PurchaseLine { get; set; }
        public virtual ICollection<PurchasePaymentLine> PurchasePaymentLine { get; set; }
    }
}
