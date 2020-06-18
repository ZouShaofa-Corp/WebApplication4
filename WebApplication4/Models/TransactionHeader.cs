using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class TransactionHeader
    {
        public TransactionHeader()
        {
            TransactionLine = new HashSet<TransactionLine>();
        }

        public int TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public int? TransactionTypeId { get; set; }
        public int? ReferenceId { get; set; }

        public virtual TransactionType TransactionType { get; set; }
        public virtual ICollection<TransactionLine> TransactionLine { get; set; }
    }
}
