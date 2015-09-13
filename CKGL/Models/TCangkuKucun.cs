using System;
using System.Collections.Generic;

namespace CKGL.Models
{
    public partial class TCangkuKucun
    {
        public TCangkuKucun()
        {
            this.TCangkuKucunMXes = new List<TCangkuKucunMX>();
        }

        public int id { get; set; }
        public int cangkuid { get; set; }
        public System.DateTime shangbaoshijian { get; set; }
        public virtual TCangku TCangku { get; set; }
        public virtual ICollection<TCangkuKucunMX> TCangkuKucunMXes { get; set; }
    }
}
