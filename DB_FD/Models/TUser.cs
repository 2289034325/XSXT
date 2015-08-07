using System;
using System.Collections.Generic;

namespace DB_FD.Models
{
    public partial class TUser
    {
        public TUser()
        {
            this.TJinchuhuos = new List<TJinchuhuo>();
            this.TKucunXZs = new List<TKucunXZ>();
            this.TXiaoshous = new List<TXiaoshou>();
        }

        public int id { get; set; }
        public string dengluming { get; set; }
        public string mima { get; set; }
        public string yonghuming { get; set; }
        public byte juese { get; set; }
        public string beizhu { get; set; }
        public byte zhuangtai { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiuggaishijian { get; set; }
        public virtual ICollection<TJinchuhuo> TJinchuhuos { get; set; }
        public virtual ICollection<TKucunXZ> TKucunXZs { get; set; }
        public virtual ICollection<TXiaoshou> TXiaoshous { get; set; }
    }
}
