using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class ErrorCategory
    {
        public ErrorCategory()
        {
            ErrorMessage = new HashSet<ErrorMessage>();
        }

        public int ErrorCategoryId { get; set; }
        public string ErrorCategoryDescription { get; set; }
        public int? ErrorTypeId { get; set; }

        public virtual ErrorType ErrorType { get; set; }
        public virtual ICollection<ErrorMessage> ErrorMessage { get; set; }
    }
}
