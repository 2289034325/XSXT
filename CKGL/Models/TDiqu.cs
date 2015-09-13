using System;
using System.Collections.Generic;

namespace CKGL.Models
{
    public partial class TDiqu
    {
        public TDiqu()
        {
            this.TDiqu1 = new List<TDiqu>();
            this.TFendians = new List<TFendian>();
            this.TJiamengshangs = new List<TJiamengshang>();
        }

        public int id { get; set; }
        public string mingcheng { get; set; }
        public Nullable<int> fid { get; set; }
        public string lsmingcheng { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual ICollection<TDiqu> TDiqu1 { get; set; }
        public virtual TDiqu TDiqu2 { get; set; }
        public virtual ICollection<TFendian> TFendians { get; set; }
        public virtual ICollection<TJiamengshang> TJiamengshangs { get; set; }
    }
}
