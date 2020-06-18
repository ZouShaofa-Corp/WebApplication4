using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class PurchasePaymentLine
    {
        public int PaymentId { get; set; }
        public int PaymentLineNumber { get; set; }
        public int? PurchaseId { get; set; }
        public decimal? Amount { get; set; }

        public virtual PurchasePayment Payment { get; set; }
        public virtual PurchaseHeader Purchase { get; set; }
    }
}
