

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TXiaoshou
    {

        public int id { get; set; }

        public int fendianid { get; set; }

        public int oid { get; set; }

        public System.DateTime xiaoshoushijian { get; set; }

        public Nullable<System.DateTime> jinhuoriqi { get; set; }

        public string xiaoshouyuan { get; set; }

        public Nullable<int> huiyuanid { get; set; }

        public Nullable<int> tiaomaid { get; set; }

        public short shuliang { get; set; }

        public decimal jinjia { get; set; }

        public decimal shoujia { get; set; }

        public decimal zhekou { get; set; }

        public decimal moling { get; set; }

        public string beizhu { get; set; }

        public System.DateTime shangbaoshijian { get; set; }

        public virtual TFendian TFendian { get; set; }

        public virtual THuiyuan THuiyuan { get; set; }

        public virtual TTiaoma TTiaoma { get; set; }

    }
}
