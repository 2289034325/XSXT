using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIANMA
{
    public class XTCONSTS
    {
        //新款旧款
        public enum KUANHAO_XINJIU : byte
        {
            新款号=1,
            既存款号=2
        }

        //条码新旧
        public enum TIAOMA_XINJIU : byte
        {
            新条码 = 1,
            既存条码 = 2
        }

        /// <summary>
        /// 从文件导入条码的列顺序
        /// </summary>
        public enum FILE_COLUMN : byte
        {
            条码 = 0,
            款号 = 1,
            类型 = 2,
            品名 = 3,
            颜色 = 4,
            尺码 = 5,
            数量 = 6,
            进价 = 7,
            售价 = 8
        }
    }
}
