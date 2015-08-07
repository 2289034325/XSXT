using System;
using System.Collections.Generic;

namespace DB_FD.Models
{
    public partial class TPandian
    {
        public int id { get; set; }
        public int tiaomaid { get; set; }
        public short pdshuliang { get; set; }
        public short kcshuliang { get; set; }
        public System.DateTime charushijian { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
    }
}
