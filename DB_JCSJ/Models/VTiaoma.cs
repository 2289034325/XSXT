using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class VTiaoma
    {
        public int id { get; set; }
        public byte laiyuan { get; set; }
        public int jmsid { get; set; }
        public string jms { get; set; }
        public int ppid { get; set; }
        public string pinpai { get; set; }
        public int kuanhaoid { get; set; }
        public string kuanhao { get; set; }
        public byte leixing { get; set; }
        public string pinming { get; set; }
        public int gysid { get; set; }
        public string gys { get; set; }
        public string gyskuanhao { get; set; }
        public string tiaoma { get; set; }
        public string yanse { get; set; }
        public string chima { get; set; }
        public decimal jinjia { get; set; }
        public decimal shoujia { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
    }
}
