using System;
using System.Text;

namespace Tool.DB.CK
{
        public class DBCONSTS
        {
            /// <summary>
            /// 系统角色
            /// </summary>
            public enum USER_XTJS : byte
            {
                系统管理员 = 1,
                仓库管理员 = 2
            }
            
            /// <summary>
            /// 系统用户状态
            /// </summary>
            public enum USER_ZT : byte
            {
                停用 = 0,
                可用 = 1
            }

            /// <summary>
            /// 进出方向
            /// </summary>
            public enum CRK_FX : byte
            {
                入=1,
                出=2
            }
            /// <summary>
            /// 进出货的来源去向
            /// </summary>
            public enum CRK_LYQX : byte
            {
                新货 = 1,
                内部 = 2,
                退货 = 3,
                丢弃 = 4,
                其他 = 99
            }
        }

}
