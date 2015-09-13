using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TTiaomaJinjia
    {
        public int id { get; set; }
        public int tmid { get; set; }
        public int jmsid { get; set; }
        public decimal jinjia { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual TJiamengshang TJiamengshang { get; set; }
        public virtual TTiaoma TTiaoma { get; set; }
    }
}
