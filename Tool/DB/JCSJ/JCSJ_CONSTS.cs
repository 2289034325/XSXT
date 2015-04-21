using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DB.JCSJ
{
    public class CONSTS
    {
        /// <summary>
        /// 系统角色
        /// </summary>
        public enum USER_XTJS : byte
        {
            系统管理员 = 1,
            总经理 = 2,
            编码员 = 3,
            照片上传 = 4
        }

        /// <summary>
        /// 系统用户状态
        /// </summary>
        public enum USER_ZT : byte
        {
            停用=0,
            可用=1
        }

        /// <summary>
        /// 分店状态
        /// </summary>
        public enum FENDIAN_ZT : byte
        {
            营业中=1,
            关闭=0
        }

        /// <summary>
        /// 分店的服装性别
        /// </summary>
        public enum FENDIAN_FZXB : byte
        {
            男=1,
            女=0,
            混合=2
        }

        /// <summary>
        /// 分店服装类型
        /// </summary>
        public enum FENDIAN_FZLX : byte
        {
            混合=1,
            衣服=2,
            鞋店=3,
            包店=4
        }

        /// <summary>
        /// 分店档次定位
        /// </summary>
        public enum FENDIAN_DC : byte
        {
            低=1,
            中=2,
            高=3
        }

        /// <summary>
        /// 分店的店铺占有性质
        /// </summary>
        public enum FENDIAN_DPXZ : byte
        {
            租赁=1,
            买断=2
        }

        /// <summary>
        /// 会员性别
        /// </summary>
        public enum HUIYUAN_XB : byte
        {
            男=1,
            女=0
        }

        /// <summary>
        /// 款号类型
        /// </summary>
        public enum KUANHAO_LX : byte
        {
            衣服=1,
            裙子=2,
            裤子=3,
            鞋子=4,
            包=5,
            配件=6
        }
    }
}
