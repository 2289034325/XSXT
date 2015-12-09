

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TJiamengGX
    {

        public int id { get; set; }

        public int ppsid { get; set; }

        public int jmsid { get; set; }

        public string bzmingcheng { get; set; }

        public string beizhu { get; set; }

        public System.DateTime charushijian { get; set; }

        public virtual TJiamengshang TJiamengshang { get; set; }

        public virtual TPinpaishang TPinpaishang { get; set; }

    }
}
