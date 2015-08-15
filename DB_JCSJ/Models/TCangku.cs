using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TCangku
    {
        public TCangku()
        {
            this.TCangkuJinchuhuos = new List<TCangkuJinchuhuo>();
            this.TCangkuKucuns = new List<TCangkuKucun>();
            this.TUser_Cangku = new List<TUser_Cangku>();
        }

        public int id { get; set; }
        public int jmsid { get; set; }
        public string mingcheng { get; set; }
        public string dizhi { get; set; }
        public string lianxiren { get; set; }
        public string dianhua { get; set; }
        public string beizhu { get; set; }
        public string jiqima { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual TJiamengshang TJiamengshang { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TCangkuJinchuhuo> TCangkuJinchuhuos { get; set; }
        public virtual ICollection<TCangkuKucun> TCangkuKucuns { get; set; }
        public virtual ICollection<TUser_Cangku> TUser_Cangku { get; set; }
    }
}
