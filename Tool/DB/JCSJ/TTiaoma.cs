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
    
    public partial class TTiaoma
    {
        public int id { get; set; }
        public int kuanhaoid { get; set; }
        public string gyskuanhao { get; set; }
        public string tiaoma { get; set; }
        public string yanse { get; set; }
        public string chima { get; set; }
        public decimal jinjia { get; set; }
        public decimal shoujia { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
    
        public virtual TKuanhao TKuanhao { get; set; }
        public virtual TUser TUser { get; set; }
    }
}
