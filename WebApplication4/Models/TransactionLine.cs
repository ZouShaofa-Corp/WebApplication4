using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class TransactionLine
    {
        public int TransactionId { get; set; }
        public int TransactionLineId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string AccountSign { get; set; }

        public virtual Account Account { get; set; }
        public virtual TransactionHeader Transaction { get; set; }
    }
}
