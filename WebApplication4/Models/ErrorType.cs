using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class ErrorType
    {
        public ErrorType()
        {
            ErrorCategory = new HashSet<ErrorCategory>();
        }

        public int ErrorTypeId { get; set; }
        public string ErrorType1 { get; set; }

        public virtual ICollection<ErrorCategory> ErrorCategory { get; set; }
    }
}
