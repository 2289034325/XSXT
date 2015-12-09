

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TUserFendian
    {

        public int id { get; set; }

        public int userid { get; set; }

        public int fendianid { get; set; }

        public virtual TFendian TFendian { get; set; }

        public virtual TUser TUser { get; set; }

    }
}
