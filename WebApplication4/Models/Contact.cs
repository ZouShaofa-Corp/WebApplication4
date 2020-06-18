using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class Contact
    {
        public Contact()
        {
            PurchaseHeader = new HashSet<PurchaseHeader>();
            SalesHeader = new HashSet<SalesHeader>();
        }

        public int ContactId { get; set; }
        public string ContactType { get; set; }
        public string ContactName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public int? Postcode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ContactNotes { get; set; }
        public decimal? Opening { get; set; }
        public decimal? TotalDr { get; set; }
        public decimal? TotalCr { get; set; }
        public decimal? Closing { get; set; }

        public virtual ICollection<PurchaseHeader> PurchaseHeader { get; set; }
        public virtual ICollection<SalesHeader> SalesHeader { get; set; }
    }
}
