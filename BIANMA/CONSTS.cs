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
            新=1,
            旧=2
        }

        //条码新旧
        public enum TIAOMA_XINJIU : byte
        {
            新 = 1,
            旧 = 2
        }

        /// <summary>
        /// 从文件导入条码的列顺序
        /// </summary>
        public enum FILE_COLUMN : byte
        {
            条码 = 0,
            款号 = 1,
            //类型 = 2,
            品名 = 2,
            颜色 = 3,
            尺码 = 4,
            数量 = 5,
            进价 = 6,
            吊牌价 = 7
        }

        /// <summary>
        /// 自编码：新款号和新条码属于自己的品牌
        /// 下载编码：不能新增款号，条码来自于加盟品牌
        /// </summary>
        public enum BM_MOD : byte
        {
            自编码 = 0,
            下载编码 = 1
        }
    }
}
