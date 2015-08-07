using System;
using System.Collections.Generic;

namespace DB_CK.Models
{
    public partial class TUser
    {
        public TUser()
        {
            this.TChurukus = new List<TChuruku>();
            this.TKucunXZs = new List<TKucunXZ>();
        }

        public int id { get; set; }
        public string dengluming { get; set; }
        public string mima { get; set; }
        public string yonghuming { get; set; }
        public byte juese { get; set; }
        public string beizhu { get; set; }
        public byte zhuangtai { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual ICollection<TChuruku> TChurukus { get; set; }
        public virtual ICollection<TKucunXZ> TKucunXZs { get; set; }
    }
}
