using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TCangkuKucunMX
    {
        public int id { get; set; }
        public int kucunid { get; set; }
        public int tiaomaid { get; set; }
        public short shuliang { get; set; }
        public Nullable<System.DateTime> jinhuoriqi { get; set; }
        public virtual TCangkuKucun TCangkuKucun { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
    }
}
