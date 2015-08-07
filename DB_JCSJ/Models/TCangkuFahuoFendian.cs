using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TCangkuFahuoFendian
    {
        public int id { get; set; }
        public int ckjinchuid { get; set; }
        public int fendianid { get; set; }
        public System.DateTime scshijian { get; set; }
        public Nullable<System.DateTime> xzshijian { get; set; }
        public virtual TCangkuJinchuhuo TCangkuJinchuhuo { get; set; }
        public virtual TFendian TFendian { get; set; }
    }
}
