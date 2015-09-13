using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TCangkuJinchuhuo
    {
        public TCangkuJinchuhuo()
        {
            this.TCangkuFahuoFendians = new List<TCangkuFahuoFendian>();
            this.TCangkuJinchuhuoMXes = new List<TCangkuJinchuhuoMX>();
        }

        public int id { get; set; }
        public int fsckid { get; set; }
        public int oid { get; set; }
        public byte fangxiang { get; set; }
        public byte laiyuanquxiang { get; set; }
        public Nullable<int> gxckid { get; set; }
        public Nullable<int> fdid { get; set; }
        public Nullable<int> jmsid { get; set; }
        public Nullable<decimal> zhekou { get; set; }
        public string beizhu { get; set; }
        public System.DateTime fashengshijian { get; set; }
        public System.DateTime shangbaoshijian { get; set; }
        public virtual TCangku FaShengCangku { get; set; }
        public virtual TCangku GuanxiCangku { get; set; }
        public virtual ICollection<TCangkuFahuoFendian> TCangkuFahuoFendians { get; set; }
        public virtual TFendian TFendian { get; set; }
        public virtual TJiamengshang TJiamengshang { get; set; }
        public virtual ICollection<TCangkuJinchuhuoMX> TCangkuJinchuhuoMXes { get; set; }
    }
}
