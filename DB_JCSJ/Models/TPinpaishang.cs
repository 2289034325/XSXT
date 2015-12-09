

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TPinpaishang
    {

        public TPinpaishang()
        {

            this.TCangkus = new List<TCangku>();

            this.TGongyingshangs = new List<TGongyingshang>();

            this.TJiamengGXes = new List<TJiamengGX>();

            this.TJiamengSQs = new List<TJiamengSQ>();

            this.TKuanhaos = new List<TKuanhao>();

            this.TPinpaishangFendians = new List<TPinpaishangFendian>();

            this.TTiaomas = new List<TTiaoma>();

            this.TUsers = new List<TUser>();

        }


        public int id { get; set; }

        public string mingcheng { get; set; }

        public short daima { get; set; }

        public string shoujihao { get; set; }

        public string youxiang { get; set; }

        public int diquid { get; set; }

        public string dizhi { get; set; }

        public string lianxiren { get; set; }

        public string dianhua { get; set; }

        public string beizhu { get; set; }

        public byte zhanghaoshu { get; set; }

        public int kuanhaoshu { get; set; }

        public int tiaomashu { get; set; }

        public byte cangkushu { get; set; }

        public int jchjilushu { get; set; }

        public int kcjilushu { get; set; }

        public short jmsshu { get; set; }

        public short gysshu { get; set; }

        public string dtyzm { get; set; }

        public System.DateTime charushijian { get; set; }

        public System.DateTime xiugaishijian { get; set; }

        public virtual ICollection<TCangku> TCangkus { get; set; }

        public virtual TDiqu TDiqu { get; set; }

        public virtual ICollection<TGongyingshang> TGongyingshangs { get; set; }

        public virtual ICollection<TJiamengGX> TJiamengGXes { get; set; }

        public virtual ICollection<TJiamengSQ> TJiamengSQs { get; set; }

        public virtual ICollection<TKuanhao> TKuanhaos { get; set; }

        public virtual ICollection<TPinpaishangFendian> TPinpaishangFendians { get; set; }

        public virtual ICollection<TTiaoma> TTiaomas { get; set; }

        public virtual ICollection<TUser> TUsers { get; set; }

    }
}
