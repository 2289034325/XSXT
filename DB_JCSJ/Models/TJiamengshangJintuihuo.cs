using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TJiamengshangJintuihuo
    {
        public TJiamengshangJintuihuo()
        {
            this.TJiamengshangJintuihuoMXes = new List<TJiamengshangJintuihuoMX>();
        }

        public int id { get; set; }
        public int dlsid { get; set; }
        public int jmsid { get; set; }
        public byte fangxiang { get; set; }
        public System.DateTime fashengriqi { get; set; }
        public decimal zhekou { get; set; }
        public string beizhu { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual TJiamengshang Dls { get; set; }
        public virtual TJiamengshang Jms { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TJiamengshangJintuihuoMX> TJiamengshangJintuihuoMXes { get; set; }
    }
}
