//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_FD
{
    using System;
    using System.Collections.Generic;
    
    public partial class TXiaoshou
    {
        public int id { get; set; }
        public System.DateTime xiaoshoushijian { get; set; }
        public string xiaoshouyuan { get; set; }
        public int tiaomaid { get; set; }
        public Nullable<int> huiyuanid { get; set; }
        public short shuliang { get; set; }
        public decimal danjia { get; set; }
        public decimal zhekou { get; set; }
        public decimal moling { get; set; }
        public Nullable<decimal> jine { get; set; }
        public string beizhu { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public Nullable<System.DateTime> shangbaoshijian { get; set; }
    
        public virtual THuiyuan THuiyuan { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
    }
}
