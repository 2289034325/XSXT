using System;
using System.Text;

namespace Tool.FD
{
        public class DBCONSTS
        {
            /// <summary>
            /// 系统角色
            /// </summary>
            public enum USER_XTJS : byte
            {
                系统管理员=1,
                店长 = 2,
                店员 = 3
            }
            
            /// <summary>
            /// 系统用户状态
            /// </summary>
            public enum USER_ZT : byte
            {
                停用 = 0,
                可用 = 1
            }

        }

}
