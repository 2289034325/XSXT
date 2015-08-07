using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TUser_Fendian
    {
        public int id { get; set; }
        public int yonghuid { get; set; }
        public int fendianid { get; set; }
        public virtual TFendian TFendian { get; set; }
        public virtual TUser TUser { get; set; }
    }
}
