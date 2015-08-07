using System;
using System.Collections.Generic;

namespace DB_FD.Models
{
    public partial class TKucunXZ
    {
        public int id { get; set; }
        public int tiaomaid { get; set; }
        public short shuliang { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
        public virtual TUser TUser { get; set; }
    }
}
