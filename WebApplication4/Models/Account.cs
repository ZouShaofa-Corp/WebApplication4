using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class Account
    {
        public Account()
        {
            ItemCostAccount = new HashSet<Item>();
            ItemInventoryAccount = new HashSet<Item>();
            PurchasePayment = new HashSet<PurchasePayment>();
            SalesLine = new HashSet<SalesLine>();
            SalesReceipt = new HashSet<SalesReceipt>();
            TransactionLine = new HashSet<TransactionLine>();
        }

        public int AccountId { get; set; }
        public int AccountCategoryId { get; set; }
        public int? AccountTypeId { get; set; }
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal? Opening { get; set; }

        public virtual AccountCategory AccountCategory { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Item> ItemCostAccount { get; set; }
        public virtual ICollection<Item> ItemInventoryAccount { get; set; }
        public virtual ICollection<PurchasePayment> PurchasePayment { get; set; }
        public virtual ICollection<SalesLine> SalesLine { get; set; }
        public virtual ICollection<SalesReceipt> SalesReceipt { get; set; }
        public virtual ICollection<TransactionLine> TransactionLine { get; set; }
    }
}
