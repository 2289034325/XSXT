using CKGL.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKGL
{
    public class CommonFunc
    {
        /// <summary>
        /// 检查到数据中心的连接状态
        /// </summary>
        /// <param name="jdc"></param>
        /// <returns></returns>
        public static JCSJData.DataServiceClient LoginJCSJ(JCSJData.DataServiceClient jdc)
        {
            if (jdc == null)
            {
                jdc = new JCSJData.DataServiceClient();
                jdc.CKZHLogin(Settings.Default.CKID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
            }
            else
            {
                if (jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    jdc = new JCSJData.DataServiceClient();
                    jdc.CKZHLogin(Settings.Default.CKID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
                }
            }

            return jdc;
        }
    }
}
