using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TUser_Cangku
    {
        public int id { get; set; }
        public int yonghuid { get; set; }
        public int cangkuid { get; set; }
        public virtual TCangku TCangku { get; set; }
        public virtual TUser TUser { get; set; }
    }
}
