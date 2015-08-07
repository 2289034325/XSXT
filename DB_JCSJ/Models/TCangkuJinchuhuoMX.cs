using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TCangkuJinchuhuoMX
    {
        public int id { get; set; }
        public int jinchuhuoid { get; set; }
        public int tiaomaid { get; set; }
        public short shuliang { get; set; }
        public virtual TCangkuJinchuhuo TCangkuJinchuhuo { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
    }
}
