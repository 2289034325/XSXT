

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TDiqu
    {

        public TDiqu()
        {

            this.Zdqs = new List<TDiqu>();

            this.TFendians = new List<TFendian>();

            this.TJiamengshangs = new List<TJiamengshang>();

            this.TPinpaishangs = new List<TPinpaishang>();

        }


        public int id { get; set; }

        public string mingcheng { get; set; }

        public Nullable<int> fid { get; set; }

        public string lsmingcheng { get; set; }

        public System.DateTime xiugaishijian { get; set; }

        public virtual ICollection<TDiqu> Zdqs { get; set; }

        public virtual TDiqu Fdq { get; set; }

        public virtual ICollection<TFendian> TFendians { get; set; }

        public virtual ICollection<TJiamengshang> TJiamengshangs { get; set; }

        public virtual ICollection<TPinpaishang> TPinpaishangs { get; set; }

    }
}
