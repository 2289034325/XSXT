//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tool.DB.JCSJ
{
    using System;
    using System.Collections.Generic;
    
    public partial class THuiyuan
    {
        public int id { get; set; }
        public int fendianid { get; set; }
        public string shoujihao { get; set; }
        public string xingming { get; set; }
        public byte xingbie { get; set; }
        public System.DateTime shengri { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public string beizhu { get; set; }
    
        public virtual TFendian TFendian { get; set; }
        public virtual TUser TUser { get; set; }
    }
}
