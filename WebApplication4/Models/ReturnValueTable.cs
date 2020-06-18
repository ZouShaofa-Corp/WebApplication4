using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class ReturnValueTable
    {
        public Guid Id { get; set; }
        public string ReturnValue { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
