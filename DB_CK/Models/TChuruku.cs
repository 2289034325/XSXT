using System;
using System.Collections.Generic;

namespace DB_CK.Models
{
    public partial class TChuruku
    {
        public TChuruku()
        {
            this.TChurukuMXes = new List<TChurukuMX>();
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
        public virtual ICollection<TChurukuMX> TChurukuMXes { get; set; }
    }
}
