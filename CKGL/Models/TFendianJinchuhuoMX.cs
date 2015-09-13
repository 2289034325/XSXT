using System;
using System.Collections.Generic;

namespace CKGL.Models
{
    public partial class TFendianJinchuhuoMX
    {
        public int id { get; set; }
        public int jinchuhuoid { get; set; }
        public int tiaomaid { get; set; }
        public short shuliang { get; set; }
        public virtual TFendianJinchuhuo TFendianJinchuhuo { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
    }
}
