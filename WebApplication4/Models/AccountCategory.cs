using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class AccountCategory
    {
        public AccountCategory()
        {
            Account = new HashSet<Account>();
        }

        public int AccountCategoryId { get; set; }
        public string AccountCategoryCode { get; set; }
        public string AccountCategoryName { get; set; }
        public int? AccountCategoryLevel { get; set; }
        public int? ParentCategoryLevel { get; set; }
        public string AccountCategorySign { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
