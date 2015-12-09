

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TFendianKucun
    {

        public TFendianKucun()
        {

            this.TFendianKucunMXes = new List<TFendianKucunMX>();

        }


        public int id { get; set; }

        public int fendianid { get; set; }

        public System.DateTime shangbaoshijian { get; set; }

        public virtual TFendian TFendian { get; set; }

        public virtual ICollection<TFendianKucunMX> TFendianKucunMXes { get; set; }

    }
}
