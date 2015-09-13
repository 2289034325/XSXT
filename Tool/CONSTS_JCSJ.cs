using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.JCSJ
{
        public class DBCONSTS
        {
            /// <summary>
            /// 系统角色
            /// </summary>
            public enum USER_XTJS : byte
            {
                系统管理员 = 1,
                总经理 = 2,//具有全局数据可见权限，无数据操作权限
                管理员 = 3,//加盟商管理员，具有加盟商所有的数据可见和操作权限
                经理 = 4,//具有加盟商所有的数据可见权限
                店长 = 5,
                店员 = 6,
                编码 = 7,
                仓库 = 8
            }

            /// <summary>
            /// 仓库系统注册时的登录名前缀
            /// </summary>
            //public const string USER_DLM_PRE_CK = "CK";
            /// <summary>
            /// 分店系统注册时的登录名前缀
            /// </summary>
            //public const string USER_DLM_PRE_FD = "FD";
            /// <summary>
            /// 报表系统注册时的登录名前缀
            /// </summary>
            //public const string USER_DLM_PRE_BB = "BB";

            /// <summary>
            /// 系统用户状态
            /// </summary>
            public enum USER_ZT : byte
            {
                停用 = 0,
                可用 = 1
            }

            /// <summary>
            /// 分店状态
            /// </summary>
            public enum FENDIAN_ZT : byte
            {
                营业中 = 1,
                关闭 = 0
            }

            /// <summary>
            /// 分店的服装性别
            /// </summary>
            public enum FENDIAN_FZXB : byte
            {
                男 = 1,
                女 = 0,
                混合 = 2
            }

            /// <summary>
            /// 分店服装类型
            /// </summary>
            public enum FENDIAN_FZLX : byte
            {
                混合 = 1,
                衣服 = 2,
                鞋店 = 3,
                包店 = 4
            }

            /// <summary>
            /// 分店档次定位
            /// </summary>
            public enum FENDIAN_DC : byte
            {
                低 = 1,
                中 = 2,
                高 = 3
            }

            /// <summary>
            /// 分店的店铺占有性质
            /// </summary>
            public enum FENDIAN_DPXZ : byte
            {
                租赁 = 1,
                买断 = 2
            }

            /// <summary>
            /// 会员性别
            /// </summary>
            public enum HUIYUAN_XB : byte
            {
                男 = 1,
                女 = 0
            }

            /// <summary>
            /// 款号类型
            /// </summary>
            public enum KUANHAO_LX : byte
            {
                上装 = 1,
                裙子 = 2,
                裤子 = 3,
                套装 = 4,
                鞋子 = 5,
                包 = 6,
                配件 = 7,
                其他 = 99
            }

            /// <summary>
            /// 款号性别
            /// </summary>
            public enum KUANHAO_XB : byte
            {
                女 = 0,
                男 = 1,
                通用 = 2
            }

            /// <summary>
            /// 进出方向
            /// </summary>
            public enum JCH_FX : byte
            {
                进 = 1,
                出 = 2
            }

            /// <summary>
            /// 进出货的来源去向
            /// </summary>
            public enum JCH_LYQX : byte
            {
                新货 = 1,
                分店 = 2,
                仓库 = 3,
                退货 = 4,
                丢弃 = 5,
                加盟商 = 6,
                其他 = 99
            }

            /// <summary>
            /// 客户端类型
            /// </summary>
            public enum SYS_CLIENT_TYPE : byte
            {
                分店 = 1,
                仓库 = 2,
                编码 = 3
            }

            /// <summary>
            /// 加盟申请的审核结果
            /// </summary>
            public enum JMSQ_JIEGUO : byte
            {
                待审核 = 0,
                通过 = 1,
                拒绝 = 2
            }

            /// <summary>
            /// 某个品牌是否接受加盟
            /// </summary>
            public enum JMS_PP_KJM : byte
            {
                不接受加盟 = 0,
                接受加盟 = 1
            }

            /// <summary>
            /// 条码的来源类别
            /// </summary>
            public enum TIAOMA_LY : byte
            {
                加盟 = 0,
                原创 = 1
            }
        }

}
