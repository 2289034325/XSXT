using System;
using System.Collections.Generic;

namespace DB_CK.Models
{
    public partial class TTiaoma
    {
        public TTiaoma()
        {
            this.TChurukuMXes = new List<TChurukuMX>();
            this.TKucunXZs = new List<TKucunXZ>();
        }

        public int id { get; set; }
        public string tiaoma { get; set; }
        public string kuanhao { get; set; }
        public string gongyingshang { get; set; }
        public string gyskuanhao { get; set; }
        public byte leixing { get; set; }
        public string pinming { get; set; }
        public string yanse { get; set; }
        public string chima { get; set; }
        public decimal jinjia { get; set; }
        public decimal shoujia { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual ICollection<TChurukuMX> TChurukuMXes { get; set; }
        public virtual ICollection<TKucunXZ> TKucunXZs { get; set; }
    }
}
