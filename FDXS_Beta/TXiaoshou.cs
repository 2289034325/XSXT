//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDXS_Beta
{
    using System;
    using System.Collections.Generic;
    
    public partial class TXiaoshou
    {
        public int id { get; set; }
        public int shangpinid { get; set; }
        public decimal danjia { get; set; }
        public short shuliang { get; set; }
        public decimal zhekou { get; set; }
        public decimal moling { get; set; }
        public System.DateTime charushijian { get; set; }
    
        public virtual TJintuimingxi TJintuimingxi { get; set; }
    }
}
