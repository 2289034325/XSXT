

using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TJiamengSQ
    {

        public int id { get; set; }

        public int ppsid { get; set; }

        public int jmsid { get; set; }

        public byte jieguo { get; set; }

        public System.DateTime charushijian { get; set; }

        public virtual TJiamengshang TJiamengshang { get; set; }

        public virtual TPinpaishang TPinpaishang { get; set; }

    }
}
