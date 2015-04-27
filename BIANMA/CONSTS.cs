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
            新款=1,
            旧款=2
        }

        //条码新旧
        public enum TIAOMA_XINJIU : byte
        {
            新条码 = 1,
            旧条码 = 2
        }
    }
}
