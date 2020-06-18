using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            SalesHeader = new HashSet<SalesHeader>();
            TransactionHeader = new HashSet<TransactionHeader>();
        }

        public int TransactionTypeId { get; set; }
        public string TransactionTypeDescription { get; set; }

        public virtual ICollection<SalesHeader> SalesHeader { get; set; }
        public virtual ICollection<TransactionHeader> TransactionHeader { get; set; }
    }
}
