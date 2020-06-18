using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class PurchasePayment
    {
        public PurchasePayment()
        {
            PurchasePaymentLine = new HashSet<PurchasePaymentLine>();
        }

        public int PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentDescription { get; set; }
        public int AccountId { get; set; }
        public decimal? Amount { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<PurchasePaymentLine> PurchasePaymentLine { get; set; }
    }
}
