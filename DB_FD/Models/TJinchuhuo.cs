using System;
using System.Collections.Generic;

namespace DB_FD.Models
{
    public partial class TJinchuhuo
    {
        public TJinchuhuo()
        {
            this.TJinchuMXes = new List<TJinchuMX>();
        }

        public int id { get; set; }
        public byte fangxiang { get; set; }
        public byte laiyuanquxiang { get; set; }
        public string beizhu { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public Nullable<System.DateTime> shangbaoshijian { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TJinchuMX> TJinchuMXes { get; set; }
    }
}
