using System;
using System.Collections.Generic;

namespace DB_FD.Models
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
        public decimal jifen { get; set; }
        public System.DateTime jfgxshijian { get; set; }
        public System.DateTime xxgxshijian { get; set; }
        public virtual ICollection<TXiaoshou> TXiaoshous { get; set; }
    }
}
