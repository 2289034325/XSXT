

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TFendianJinchuhuo
    {

        public TFendianJinchuhuo()
        {

            this.TFendianJinchuhuoMXes = new List<TFendianJinchuhuoMX>();

        }


        public int id { get; set; }

        public int fendianid { get; set; }

        public int oid { get; set; }

        public string picima { get; set; }

        public byte fangxiang { get; set; }

        public byte laiyuanquxiang { get; set; }

        public string beizhu { get; set; }

        public System.DateTime fashengshijian { get; set; }

        public System.DateTime shangbaoshijian { get; set; }

        public virtual TFendian TFendian { get; set; }

        public virtual ICollection<TFendianJinchuhuoMX> TFendianJinchuhuoMXes { get; set; }

    }
}
