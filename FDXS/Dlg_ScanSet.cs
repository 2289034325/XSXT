using FDXS.Properties;
using MyFormControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Dlg_ScanSet : MyForm
    {
        public Dlg_ScanSet()
        {
            InitializeComponent();
            base.InitializeComponent();
            RawInputAddIn rad = new RawInputAddIn(null, Handle, HandleScan);
        }
        private void HandleScan(string scanName)
        {
            Settings.Default.ScanName = scanName;
            Settings.Default.Save();

            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
