using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TJiamengshang
    {
        public TJiamengshang()
        {
            this.TCangkus = new List<TCangku>();
            this.TFendians = new List<TFendian>();
            this.TGongyingshangs = new List<TGongyingshang>();
            this.TKuanhaos = new List<TKuanhao>();
            this.TUsers = new List<TUser>();
        }

        public int id { get; set; }
        public string mingcheng { get; set; }
        public byte zhanghaoshu { get; set; }
        public int tiaomashu { get; set; }
        public int huiyuanshu { get; set; }
        public short fendianshu { get; set; }
        public Nullable<int> kuanhaoshu { get; set; }
        public Nullable<byte> cangkushu { get; set; }
        public Nullable<short> gongyingshangshu { get; set; }
        public Nullable<int> xsjilushu { get; set; }
        public Nullable<int> jchjilushu { get; set; }
        public Nullable<int> kcjilushu { get; set; }
        public decimal shoucifufei { get; set; }
        public decimal xufeidanjia { get; set; }
        public System.DateTime jiezhiriqi { get; set; }
        public string lianxiren { get; set; }
        public string dianhua { get; set; }
        public string beizhu { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual ICollection<TCangku> TCangkus { get; set; }
        public virtual ICollection<TFendian> TFendians { get; set; }
        public virtual ICollection<TGongyingshang> TGongyingshangs { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TKuanhao> TKuanhaos { get; set; }
        public virtual ICollection<TUser> TUsers { get; set; }
    }
}
