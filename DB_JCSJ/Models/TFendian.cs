using System;
using System.Collections.Generic;

namespace DB_JCSJ.Models
{
    public partial class TFendian
    {
        public TFendian()
        {
            this.TCangkuFahuoFendians = new List<TCangkuFahuoFendian>();
            this.TFendianJinchuhuos = new List<TFendianJinchuhuo>();
            this.TFendianKucuns = new List<TFendianKucun>();
            this.THuiyuans = new List<THuiyuan>();
            this.TUser_Fendian = new List<TUser_Fendian>();
            this.TXiaoshous = new List<TXiaoshou>();
        }

        public int id { get; set; }
        public byte fzxingbie { get; set; }
        public byte fzleixing { get; set; }
        public string dianming { get; set; }
        public short mianji { get; set; }
        public short keliuliang { get; set; }
        public byte dangci { get; set; }
        public byte dpxingzhi { get; set; }
        public decimal zhuanrangfei { get; set; }
        public decimal yuezu { get; set; }
        public string dizhi { get; set; }
        public string lianxiren { get; set; }
        public string dianhua { get; set; }
        public System.DateTime kaidianriqi { get; set; }
        public byte zhuangtai { get; set; }
        public string beizhu { get; set; }
        public int caozuorenid { get; set; }
        public System.DateTime charushijian { get; set; }
        public System.DateTime xiugaishijian { get; set; }
        public virtual ICollection<TCangkuFahuoFendian> TCangkuFahuoFendians { get; set; }
        public virtual TUser TUser { get; set; }
        public virtual ICollection<TFendianJinchuhuo> TFendianJinchuhuos { get; set; }
        public virtual ICollection<TFendianKucun> TFendianKucuns { get; set; }
        public virtual ICollection<THuiyuan> THuiyuans { get; set; }
        public virtual ICollection<TUser_Fendian> TUser_Fendian { get; set; }
        public virtual ICollection<TXiaoshou> TXiaoshous { get; set; }
    }
}
