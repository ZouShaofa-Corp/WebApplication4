using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class Item
    {
        public Item()
        {
            PurchaseLine = new HashSet<PurchaseLine>();
            SalesLine = new HashSet<SalesLine>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? OpeningQty { get; set; }
        public decimal? OpeningAmount { get; set; }
        public decimal? QtyOnHand { get; set; }
        public string Unit { get; set; }
        public decimal? Amount { get; set; }
        public decimal? SalesPrice { get; set; }
        public int? InventoryAccountId { get; set; }
        public int? CostAccountId { get; set; }
        public int TimeBilling { get; set; }

        public virtual Account CostAccount { get; set; }
        public virtual Account InventoryAccount { get; set; }
        public virtual ICollection<PurchaseLine> PurchaseLine { get; set; }
        public virtual ICollection<SalesLine> SalesLine { get; set; }
    }
}
