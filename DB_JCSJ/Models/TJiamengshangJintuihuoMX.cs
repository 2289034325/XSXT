using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TJiamengshangJintuihuoMX
    {
        public int id { get; set; }
        public int jintuiid { get; set; }
        public int tiaomaid { get; set; }
        public decimal chengbenjia { get; set; }
        public decimal diaopaijia { get; set; }
        public decimal jinhuojia { get; set; }
        public short shuliang { get; set; }
        public virtual TJiamengshangJintuihuo TJiamengshangJintuihuo { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
    }
}
