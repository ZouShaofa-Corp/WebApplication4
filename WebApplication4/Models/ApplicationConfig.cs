using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class ApplicationConfig
    {
        public string ConfigName { get; set; }
        public string ConfigDescription { get; set; }
        public string ConfigValue { get; set; }
        public int? ConfigItemSeq { get; set; }
    }
}
