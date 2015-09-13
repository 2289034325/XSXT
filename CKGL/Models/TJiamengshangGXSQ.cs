using System;
using System.Collections.Generic;

namespace CKGL.Models
{
    public partial class TJiamengshangGXSQ
    {
        public int id { get; set; }
        public int dlsid { get; set; }
        public int ppid { get; set; }
        public int jmsid { get; set; }
        public byte jieguo { get; set; }
        public System.DateTime charushijian { get; set; }
        public virtual TJiamengshang TJiamengshang { get; set; }
        public virtual TJiamengshang TJiamengshang1 { get; set; }
        public virtual TJiamengshangPinpai TJiamengshangPinpai { get; set; }
    }
}
