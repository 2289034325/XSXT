using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TJiamengshangGX
    {
        public int id { get; set; }
        public int dlsid { get; set; }
        public int ppid { get; set; }
        public int jmsid { get; set; }
        public string bzmingcheng { get; set; }
        public string beizhu { get; set; }
        public System.DateTime charushijian { get; set; }
        public virtual TJiamengshang Dls { get; set; }
        public virtual TJiamengshang Jms { get; set; }
        public virtual TPinpai TPinpai { get; set; }
    }
}
