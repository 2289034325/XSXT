﻿using System;
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

            /// <summary>
            /// 进出方向
            /// </summary>
            public enum JCH_FX : byte
            {
                进=1,
                出=2
            }

            /// <summary>
            /// 进出货的来源去向
            /// </summary>
            public enum JCH_LYQX : byte
            {
                新货 = 1,
                内部 = 2,
                退货 = 3,
                丢弃 = 4,
                其他 = 99
            }
        }

}