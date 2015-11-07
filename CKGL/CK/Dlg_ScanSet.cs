using CKGL.Properties;
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

namespace CKGL.CK
{
    public partial class Dlg_ScanSet : Form
    {
        public Dlg_ScanSet()
        {
            InitializeComponent();
            RawInputAddIn rad = new RawInputAddIn(null, Handle, HandleScan);
        }
        private void HandleScan(string scanName)
        {
            Settings.Default.ScanName = scanName;
            Settings.Default.Save();

            Close();
        }
    }
}
