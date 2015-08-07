using System;
using System.Collections.Generic;

namespace DB_FD.Models
{
    public partial class TJinchuMX
    {
        public int id { get; set; }
        public int jinchuid { get; set; }
        public int tiaomaid { get; set; }
        public short shuliang { get; set; }
        public virtual TJinchuhuo TJinchuhuo { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
    }
}
