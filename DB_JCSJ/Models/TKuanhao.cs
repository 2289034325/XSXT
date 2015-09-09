using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TKuanhao
    {
        public TKuanhao()
        {
            this.TTiaomas = new List<TTiaoma>();
        }

        public int id { get; set; }
        public int ppid { get; set; }
        public string kuanhao { get; set; }
        public byte leixing { get; set; }
        public byte xingbie { get; set; }
        public string pinming { get; set; }
        public string beizhu { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual TJiamengshangPinpai TJiamengshangPinpai { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TTiaoma> TTiaomas { get; set; }
    }
}
