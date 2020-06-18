using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Account = new HashSet<Account>();
        }

        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
