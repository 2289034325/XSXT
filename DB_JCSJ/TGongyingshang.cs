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
    
    public partial class TGongyingshang
    {
        public TGongyingshang()
        {
            this.TTiaoma = new HashSet<TTiaoma>();
        }
    
        public int id { get; set; }
        public string jiancheng { get; set; }
        public string mingcheng { get; set; }
        public string lianxiren { get; set; }
        public string dianhua { get; set; }
        public string dizhi { get; set; }
        public string beizhu { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
    
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TTiaoma> TTiaoma { get; set; }
    }
}
