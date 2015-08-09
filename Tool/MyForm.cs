using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool
{
    public class MyForm : Form
    {
        /// <summary>
        /// 扫描枪处理
        /// </summary>
        /// <param name="tm"></param>
        public virtual void OnScan(string tm)
        {
            //基类中扫描都不做，让子窗口自己实装
        }
    }
}
