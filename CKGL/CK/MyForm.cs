using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKGL.CK
{
    public class MyForm:Form
    {
        public virtual void OnScan(string tm)
        {
            //基类中扫描都不做，让子窗口自己实装            
        }
    }
}
