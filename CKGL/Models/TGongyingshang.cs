using System;
using System.Collections.Generic;

namespace CKGL.Models
{
    public partial class TGongyingshang
    {
        public TGongyingshang()
        {
            this.TTiaomas = new List<TTiaoma>();
        }

        public int id { get; set; }
        public int jmsid { get; set; }
        public string mingcheng { get; set; }
        public string lianxiren { get; set; }
        public string dianhua { get; set; }
        public string dizhi { get; set; }
        public string beizhu { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual TJiamengshang TJiamengshang { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TTiaoma> TTiaomas { get; set; }
    }
}
