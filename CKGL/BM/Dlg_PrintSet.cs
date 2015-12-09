using CKGL;
using CKGL.BM;
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

namespace CKGL.BM
{
    public partial class Dlg_PrintSet : Form
    {
        public Dlg_PrintSet()
        {
            InitializeComponent();
        }

        private void Dlg_PrintSet_Load(object sender, EventArgs e)
        {
            string img = Settings.Default.Print_LogoImg;
            int width = Settings.Default.Print_PageWidth;
            int height = Settings.Default.Print_PageHeight;
            bool dp = Settings.Default.Print_IsDoublePage;
            int itv_h = Settings.Default.Print_PageInterval_H;
            int off_l = Settings.Default.Print_Offset_Left;
            int off_t = Settings.Default.Print_Offset_Top;

            txb_img.Text = img;
            txb_width.Text = width.ToString();
            txb_height.Text = height.ToString();
            chk_double.Checked = dp;
            txb_interval.Text = itv_h.ToString();
            txb_offset_left.Text = off_l.ToString();
            txb_offset_top.Text = off_t.ToString();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string img = txb_img.Text.Trim();
            string width = txb_width.Text.Trim();
            string height = txb_height.Text.Trim();
            bool dp = chk_double.Checked;
            string itv_h = txb_interval.Text.Trim();
            string off_l = txb_offset_left.Text.Trim();
            string off_t = txb_offset_top.Text.Trim();

            if (string.IsNullOrEmpty(img))
            {
                MessageBox.Show("请选择一个logo图片的路径");
                return;
            }
            Settings.Default.Print_LogoImg = img;
            int i;
            if (!int.TryParse(width, out i))
            {
                MessageBox.Show("标签宽度必须是一个整数");
                return;
            }
            else
            {
                Settings.Default.Print_PageWidth = i;
            }
            if (!int.TryParse(height, out i))
            {
                MessageBox.Show("标签高度必须是一个整数");
                return;
            }
            else
            {
                Settings.Default.Print_PageHeight = i;
            }

            Settings.Default.Print_IsDoublePage = chk_double.Checked;

            if (!int.TryParse(itv_h, out i))
            {
                MessageBox.Show("标签间距必须是一个整数");
                return;
            }
            else
            {
                Settings.Default.Print_PageInterval_H = i;
            }
            if (!int.TryParse(off_l, out i))
            {
                MessageBox.Show("左偏移必须是一个整数");
                return;
            }
            else
            {
                Settings.Default.Print_Offset_Left = i;
            }
            if (!int.TryParse(off_t, out i))
            {
                MessageBox.Show("顶偏移必须是一个整数");
                return;
            }
            else
            {
                Settings.Default.Print_Offset_Top = i;
            }

            Settings.Default.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fn = ofd.FileName;
                txb_img.Text = fn;
            }
        }
    }
}
