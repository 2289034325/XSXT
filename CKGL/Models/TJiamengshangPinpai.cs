using System;
using System.Collections.Generic;

namespace CKGL.Models
{
    public partial class TJiamengshangPinpai
    {
        public TJiamengshangPinpai()
        {
            this.TFendians = new List<TFendian>();
            this.TJiamengshangGXes = new List<TJiamengshangGX>();
            this.TJiamengshangGXSQs = new List<TJiamengshangGXSQ>();
            this.TKuanhaos = new List<TKuanhao>();
        }

        public int id { get; set; }
        public int jmsid { get; set; }
        public string mingcheng { get; set; }
        public byte kejiameng { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual ICollection<TFendian> TFendians { get; set; }
        public virtual TJiamengshang TJiamengshang { get; set; }
        public virtual ICollection<TJiamengshangGX> TJiamengshangGXes { get; set; }
        public virtual ICollection<TJiamengshangGXSQ> TJiamengshangGXSQs { get; set; }
        public virtual ICollection<TKuanhao> TKuanhaos { get; set; }
    }
}
