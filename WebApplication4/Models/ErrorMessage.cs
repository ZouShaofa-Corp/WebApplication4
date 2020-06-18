using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class ErrorMessage
    {
        public int ErrorMessageId { get; set; }
        public string ErrorMessage1 { get; set; }
        public string CustomMessage { get; set; }
        public int? ErrorCategoryId { get; set; }

        public virtual ErrorCategory ErrorCategory { get; set; }
    }
}
