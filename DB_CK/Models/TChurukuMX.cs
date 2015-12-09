using System;
using System.Collections.Generic;

namespace DB_CK.Models
{
    public partial class TChurukuMX
    {
        public int id { get; set; }
        public int churukuid { get; set; }
        public int tiaomaid { get; set; }
        public decimal danjia { get; set; }
        public short shuliang { get; set; }
        public virtual TChuruku TChuruku { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
    }
}
