using System;
using System.Collections.Generic;

namespace CKGL.Models
{
    public partial class TTiaoma
    {
        public TTiaoma()
        {
            this.TCangkuJinchuhuoMXes = new List<TCangkuJinchuhuoMX>();
            this.TCangkuKucunMXes = new List<TCangkuKucunMX>();
            this.TFendianJinchuhuoMXes = new List<TFendianJinchuhuoMX>();
            this.TFendianKucunMXes = new List<TFendianKucunMX>();
            this.TTiaomaJinjias = new List<TTiaomaJinjia>();
            this.TXiaoshous = new List<TXiaoshou>();
        }

        public int id { get; set; }
        public int jmsid { get; set; }
        public int kuanhaoid { get; set; }
        public int gysid { get; set; }
        public string gyskuanhao { get; set; }
        public string tiaoma { get; set; }
        public string yanse { get; set; }
        public string chima { get; set; }
        public decimal jinjia { get; set; }
        public decimal shoujia { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual ICollection<TCangkuJinchuhuoMX> TCangkuJinchuhuoMXes { get; set; }
        public virtual ICollection<TCangkuKucunMX> TCangkuKucunMXes { get; set; }
        public virtual ICollection<TFendianJinchuhuoMX> TFendianJinchuhuoMXes { get; set; }
        public virtual ICollection<TFendianKucunMX> TFendianKucunMXes { get; set; }
        public virtual TGongyingshang TGongyingshang { get; set; }
        public virtual TJiamengshang TJiamengshang { get; set; }
        public virtual TKuanhao TKuanhao { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TTiaomaJinjia> TTiaomaJinjias { get; set; }
        public virtual ICollection<TXiaoshou> TXiaoshous { get; set; }
    }
}
