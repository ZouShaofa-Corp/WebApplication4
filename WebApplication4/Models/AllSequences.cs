using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class AllSequences
    {
        public string SeqName { get; set; }
        public int Seed { get; set; }
        public int Incr { get; set; }
        public int? Currval { get; set; }
    }
}
