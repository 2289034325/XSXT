

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TJiamengshang
    {

        public TJiamengshang()
        {

            this.TCangkuJinchuhuos = new List<TCangkuJinchuhuo>();

            this.TFendians = new List<TFendian>();

            this.THuiyuans = new List<THuiyuan>();

            this.TJiamengGXes = new List<TJiamengGX>();

            this.TJiamengSQs = new List<TJiamengSQ>();

            this.TUsers = new List<TUser>();

        }


        public int id { get; set; }

        public string mingcheng { get; set; }

        public short daima { get; set; }

        public string zhuceshouji { get; set; }

        public string zhuceyouxiang { get; set; }

        public int diquid { get; set; }

        public string dizhi { get; set; }

        public string lianxiren { get; set; }

        public string dianhua { get; set; }

        public string beizhu { get; set; }

        public byte pinpaishu { get; set; }

        public byte zhanghaoshu { get; set; }

        public int huiyuanshu { get; set; }

        public short fendianshu { get; set; }

        public int xsjilushu { get; set; }

        public int jchjilushu { get; set; }

        public int kcjilushu { get; set; }

        public string dtyzm { get; set; }

        public System.DateTime charushijian { get; set; }

        public System.DateTime xiugaishijian { get; set; }

        public virtual ICollection<TCangkuJinchuhuo> TCangkuJinchuhuos { get; set; }

        public virtual TDiqu TDiqu { get; set; }

        public virtual ICollection<TFendian> TFendians { get; set; }

        public virtual ICollection<THuiyuan> THuiyuans { get; set; }

        public virtual ICollection<TJiamengGX> TJiamengGXes { get; set; }

        public virtual ICollection<TJiamengSQ> TJiamengSQs { get; set; }

        public virtual ICollection<TUser> TUsers { get; set; }

    }
}
