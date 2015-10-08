using CKGL.Properties;
using DB_CK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace CKGL
{
    public partial class Dlg_Fendian : Form
    {
        public Dlg_Fendian()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (cmb_fd.SelectedValue == null)
            {
                MessageBox.Show("请选择一个分店");
                return;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Fendian_Load(object sender, EventArgs e)
        {
            //if (RuntimeInfo.AllFds == null)
            //{
            //    new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            //    {
            //        try
            //        {
            //            JCSJData.TFendian[] fds = JCSJWCF.GetFendians();
            //            RuntimeInfo.AllFds = fds.ToDictionary(k => k.id.ToString(), v => v.dianming);
            //            Tool.CommonFunc.InitCombbox(cmb_fd, RuntimeInfo.AllFds);
            //        }
            //        catch (Exception ex)
            //        {
            //            Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
            //            ShowMsg(ex.Message, true);
            //        }
            //    }, true).Start();
            //}
        }        
    }
}
