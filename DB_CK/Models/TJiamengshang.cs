using System;
using System.Collections.Generic;

namespace DB_CK.Models
{
    public partial class TJiamengshang
    {
        public TJiamengshang()
        {
            this.TChurukus = new List<TChuruku>();
        }

        public int id { get; set; }
        public string mingcheng { get; set; }
        public short daima { get; set; }
        public string dizhi { get; set; }
        public string lianxiren { get; set; }
        public string dianhua { get; set; }
        public bool zhuangtai { get; set; }
        public virtual ICollection<TChuruku> TChurukus { get; set; }
    }
}
