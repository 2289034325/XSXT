using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TUser
    {
        public TUser()
        {
            this.TCangkus = new List<TCangku>();
            this.TFendians = new List<TFendian>();
            this.TGongyingshangs = new List<TGongyingshang>();
            this.TJiamengshangJintuihuos = new List<TJiamengshangJintuihuo>();
            this.TKuanhaos = new List<TKuanhao>();
            this.TTiaomas = new List<TTiaoma>();
            this.TUserFendians = new List<TUserFendian>();
        }

        public int id { get; set; }
        public int jmsid { get; set; }
        public string dengluming { get; set; }
        public string mima { get; set; }
        public string jiqima { get; set; }
        public string yonghuming { get; set; }
        public byte juese { get; set; }
        public string beizhu { get; set; }
        public byte zhuangtai { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual ICollection<TCangku> TCangkus { get; set; }
        public virtual ICollection<TFendian> TFendians { get; set; }
        public virtual ICollection<TGongyingshang> TGongyingshangs { get; set; }
        public virtual TJiamengshang TJiamengshang { get; set; }
        public virtual ICollection<TJiamengshangJintuihuo> TJiamengshangJintuihuos { get; set; }
        public virtual ICollection<TKuanhao> TKuanhaos { get; set; }
        public virtual ICollection<TTiaoma> TTiaomas { get; set; }
        public virtual ICollection<TUserFendian> TUserFendians { get; set; }
    }
}
