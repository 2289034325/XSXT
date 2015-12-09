

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TPinpaishangFendian
    {

        public int id { get; set; }

        public int ppsid { get; set; }

        public int fendianid { get; set; }

        public virtual TFendian TFendian { get; set; }

        public virtual TPinpaishang TPinpaishang { get; set; }

    }
}
