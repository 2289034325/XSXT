//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_JCSJ
{
    using System;
    using System.Collections.Generic;
    
    public partial class TCangkuFahuoFendian
    {
        public int id { get; set; }
        public int ckjinchuid { get; set; }
        public int fendianid { get; set; }
        public System.DateTime scshijian { get; set; }
        public Nullable<System.DateTime> xzshijian { get; set; }
    
        public virtual TCangkuJinchuhuo TCangkuJinchuhuo { get; set; }
        public virtual TFendian TFendian { get; set; }
    }
}