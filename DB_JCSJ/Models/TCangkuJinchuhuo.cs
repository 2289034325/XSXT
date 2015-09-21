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
        public int ckid { get; set; }
        public int oid { get; set; }
        public byte fangxiang { get; set; }
        public byte laiyuanquxiang { get; set; }
        public string beizhu { get; set; }
        public System.DateTime fashengshijian { get; set; }
        public System.DateTime shangbaoshijian { get; set; }
        public virtual TCangku TCangku { get; set; }
        public virtual ICollection<TCangkuFahuoFendian> TCangkuFahuoFendians { get; set; }
        public virtual ICollection<TCangkuJinchuhuoMX> TCangkuJinchuhuoMXes { get; set; }
    }
}
