using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TJiamengshang
    {
        public TJiamengshang()
        {
            this.TCangkus = new List<TCangku>();
            this.TCangkuJinchuhuos = new List<TCangkuJinchuhuo>();
            this.TFendians = new List<TFendian>();
            this.TGongyingshangs = new List<TGongyingshang>();
            this.THuiyuans = new List<THuiyuan>();
            this.XjGxes = new List<TJiamengshangGX>();
            this.SjGxes = new List<TJiamengshangGX>();
            this.SQXjGxes = new List<TJiamengshangGXSQ>();
            this.SQSjGxes = new List<TJiamengshangGXSQ>();
            this.TJiamengshangPinpais = new List<TJiamengshangPinpai>();
            this.TTiaomas = new List<TTiaoma>();
            this.TTiaomaJinjias = new List<TTiaomaJinjia>();
            this.TUsers = new List<TUser>();
        }

        public int id { get; set; }
        public string mingcheng { get; set; }
        public string zhuceshouji { get; set; }
        public string zhuceyouxiang { get; set; }
        public int diquid { get; set; }
        public string dizhi { get; set; }
        public string lianxiren { get; set; }
        public string dianhua { get; set; }
        public string beizhu { get; set; }
        public byte fjmsshu { get; set; }
        public short zjmsshu { get; set; }
        public byte ppshu { get; set; }
        public byte zhanghaoshu { get; set; }
        public int tiaomashu { get; set; }
        public int huiyuanshu { get; set; }
        public short fendianshu { get; set; }
        public int kuanhaoshu { get; set; }
        public byte cangkushu { get; set; }
        public short gongyingshangshu { get; set; }
        public int xsjilushu { get; set; }
        public int jchjilushu { get; set; }
        public int kcjilushu { get; set; }
        public decimal shoucifufei { get; set; }
        public decimal xufeidanjia { get; set; }
        public System.DateTime jiezhiriqi { get; set; }
        public string dtyzm { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual ICollection<TCangku> TCangkus { get; set; }
        public virtual ICollection<TCangkuJinchuhuo> TCangkuJinchuhuos { get; set; }
        public virtual TDiqu TDiqu { get; set; }
        public virtual ICollection<TFendian> TFendians { get; set; }
        public virtual ICollection<TGongyingshang> TGongyingshangs { get; set; }
        public virtual ICollection<THuiyuan> THuiyuans { get; set; }
        public virtual ICollection<TJiamengshangGX> XjGxes { get; set; }
        public virtual ICollection<TJiamengshangGX> SjGxes { get; set; }
        public virtual ICollection<TJiamengshangGXSQ> SQXjGxes { get; set; }
        public virtual ICollection<TJiamengshangGXSQ> SQSjGxes { get; set; }
        public virtual ICollection<TJiamengshangPinpai> TJiamengshangPinpais { get; set; }
        public virtual ICollection<TTiaoma> TTiaomas { get; set; }
        public virtual ICollection<TTiaomaJinjia> TTiaomaJinjias { get; set; }
        public virtual ICollection<TUser> TUsers { get; set; }
    }
}
