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
    
    public partial class TUser
    {
        public TUser()
        {
            this.TGongyingshang = new HashSet<TGongyingshang>();
            this.TKuanhao = new HashSet<TKuanhao>();
            this.TTiaoma = new HashSet<TTiaoma>();
            this.TCangku = new HashSet<TCangku>();
            this.THuiyuan = new HashSet<THuiyuan>();
            this.TFendian = new HashSet<TFendian>();
        }
    
        public int id { get; set; }
        public string dengluming { get; set; }
        public string mima { get; set; }
        public string yonghuming { get; set; }
        public byte juese { get; set; }
        public string beizhu { get; set; }
        public byte zhuangtai { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
    
        public virtual ICollection<TGongyingshang> TGongyingshang { get; set; }
        public virtual ICollection<TKuanhao> TKuanhao { get; set; }
        public virtual ICollection<TTiaoma> TTiaoma { get; set; }
        public virtual ICollection<TCangku> TCangku { get; set; }
        public virtual ICollection<THuiyuan> THuiyuan { get; set; }
        public virtual ICollection<TFendian> TFendian { get; set; }
    }
}
