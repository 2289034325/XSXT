using DB_CK;
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

namespace CKGL
{
    public partial class Dlg_AppSettings : Form
    {
        public Dlg_AppSettings()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string dbserver = txb_dbserver.Text.Trim();
            string dbname = txb_dbname.Text.Trim();
            string dbuser = txb_dbuser.Text.Trim();
            string dbpsw = txb_dbpsw.Text;
            string validadd = txb_validadd.Text.Trim();
            string dataadd = txb_dataadd.Text.Trim();

            if (string.IsNullOrEmpty(dbname) || string.IsNullOrEmpty(dbuser) ||
                string.IsNullOrEmpty(dbpsw) || string.IsNullOrEmpty(validadd) ||
                string.IsNullOrEmpty(dbserver) || string.IsNullOrEmpty(dataadd))
            {
                MessageBox.Show("不能输入空白");
                return;
            }

            Settings.Default.DBSERVER = dbserver;
            Settings.Default.DBName = dbname;
            Settings.Default.DBUSER = dbuser;
            Settings.Default.DBPSW = dbpsw;
            Settings.Default.WCFValidADD = validadd;
            Settings.Default.WCFDataADD = dataadd;

            Settings.Default.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_AppSettings_Load(object sender, EventArgs e)
        {
            txb_dbserver.Text = Settings.Default.DBSERVER;
            txb_dbname.Text = Settings.Default.DBName;
            txb_dbuser.Text = Settings.Default.DBUSER;
            txb_dbpsw.Text = Settings.Default.DBPSW;
            txb_validadd.Text = Settings.Default.WCFValidADD;
            txb_dataadd.Text = Settings.Default.WCFDataADD.ToString();
        }
    }
}
