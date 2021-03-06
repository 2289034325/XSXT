using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class THuiyuan
    {
        public THuiyuan()
        {
            this.TXiaoshous = new List<TXiaoshou>();
        }

        public int id { get; set; }
        public int fendianid { get; set; }
        public string shoujihao { get; set; }
        public string xingming { get; set; }
        public byte xingbie { get; set; }
        public System.DateTime shengri { get; set; }
        public string beizhu { get; set; }
        public decimal jifen { get; set; }
        public System.DateTime jfjsshijian { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual TFendian TFendian { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TXiaoshou> TXiaoshous { get; set; }
    }
}
