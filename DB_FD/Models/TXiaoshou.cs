using System;
using System.Collections.Generic;

namespace DB_FD.Models
{
    public partial class TXiaoshou
    {
        public int id { get; set; }
        public System.DateTime xiaoshoushijian { get; set; }
        public string xiaoshouyuan { get; set; }
        public Nullable<int> huiyuanid { get; set; }
        public Nullable<int> tiaomaid { get; set; }
        public short shuliang { get; set; }
        public decimal jinjia { get; set; }
        public decimal shoujia { get; set; }
        public decimal zhekou { get; set; }
        public decimal moling { get; set; }
        public string beizhu { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public Nullable<System.DateTime> shangbaoshijian { get; set; }
        public virtual THuiyuan THuiyuan { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
        public virtual TUser TUser { get; set; }
    }
}
