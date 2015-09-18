using BIANMA.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace BIANMA
{
    public partial class Dlg_Biaoqian : Form
    {
        private const string _basePath = "Biaoqian\\";
        private const string _baseFile = "Biaoqian\\Base.htm";
        private string _currentFile;
        private DataTable _data;

        public Dlg_Biaoqian(DataTable dt)
        {
            InitializeComponent();
            _data = dt;
            _currentFile = null;
        }

        /// <summary>
        /// 新建一个标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xjbq_Click(object sender, EventArgs e)
        {
            string fn = txb_bqmc.Text.Trim();
            if (string.IsNullOrEmpty(fn))
            {
                MessageBox.Show("请输入一个名称");
                return;
            }
            string afn = _basePath + fn + ".html";

            File.Copy(_baseFile, afn);

            string ffn = Application.StartupPath + "\\" + afn;
            Uri uri = new Uri(ffn);
            wb.Navigate(uri);

            _currentFile = ffn;

            initCmb_bq();
        }

        /// <summary>
        /// 保存标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bcbq_Click(object sender, EventArgs e)
        {
            if(_currentFile == null)
            {
                MessageBox.Show("请先创建或者打开一个文件，然后再保存");
                return;
            }
            StreamWriter sw = new StreamWriter(_currentFile,false);
            sw.Write(wb.DocumentText);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Biaoqian_Load(object sender, EventArgs e)
        {
            grid.DataSource = _data;
            foreach (DataGridViewRow dr in grid.Rows)
            {
                dr.Cells[col_xh.Name].Value = dr.Index + 1;
            }

            //初始化下拉框
            initCmb_bq();

            Tool.CommonFunc.InitCombbox(cmb_type, typeof(BQ_LX));
            Dictionary<string,string> fds = new Dictionary<string,string>();
            fds.Add("col_xh","序号");
            fds.Add("col_tm", "条码");
            fds.Add("col_kh", "款号");
            fds.Add("col_pm", "品名");
            fds.Add("col_ys", "颜色");
            fds.Add("col_cm", "尺码");
            fds.Add("col_dpj", "吊牌价");
            fds.Add("col_gys", "供应商");
            fds.Add("col_gyskh", "供应商款号");
            Tool.CommonFunc.InitCombbox(cmb_field, fds);    
        }

        private void initCmb_bq()
        {
            string[] fns = Directory.GetFiles(_basePath, "*.html");
            Dictionary<string, string> dfns = new Dictionary<string, string>();
            foreach (string fn in fns)
            {
                FileInfo fi = new FileInfo(fn);
                dfns.Add(fi.FullName, fi.Name.Replace(fi.Extension, ""));
            }
            Tool.CommonFunc.InitCombbox(cmb_bq, dfns);
        }

        /// <summary>
        /// 插入一个元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_charu_Click(object sender, EventArgs e)
        {
            string type = cmb_type.SelectedValue.ToString();
            string filed = cmb_field.SelectedValue == null ? "" : cmb_field.SelectedValue.ToString();
            List<object> args = new List<object>();
            args.Add(type);
            args.Add(filed);
            args.Add("100px");
            args.Add("40px;");
            string value = "文本";
            if (type.ToString() == ((byte)BQ_LX.变量).ToString() )
            {
                if (grid.SelectedRows.Count > 0)
                {
                    value = grid.SelectedRows[0].Cells[filed].Value.ToString();
                }
                else
                {
                    value = "变量";
                }
            }
            args.Add(value);
            wb.Document.InvokeScript("addDiv", args.ToArray());
        }

        /// <summary>
        /// 打开标签文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dkbq_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(cmb_bq.SelectedValue.ToString());
            wb.Navigate(uri);

            _currentFile = cmb_bq.SelectedValue.ToString();
        }

        /// <summary>
        /// 删除选中的标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_scbq_Click(object sender, EventArgs e)
        {
            if (cmb_bq.SelectedValue == null)
            {
                MessageBox.Show("请先选择要删除的文件");
                return;
            }

            if (cmb_bq.SelectedValue.ToString() == _currentFile)
            {
                MessageBox.Show("不能删除当前正在编辑的文件");
                return;
            }

            string fn = cmb_bq.SelectedValue.ToString();
            File.Delete(fn);

            initCmb_bq();
        }

        /// <summary>
        /// 设置标签大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bqdx_Click(object sender, EventArgs e)
        {
            int width, height;
            if (!int.TryParse(txb_bqw.Text.Trim(), out width))
            {
                MessageBox.Show("请输入数字");
                return;
            }
            if (!int.TryParse(txb_bqh.Text.Trim(), out height))
            {
                MessageBox.Show("请输入数字");
                return;
            }

            List<object> args = new List<object>();
            args.Add(width + "px");
            args.Add(height + "px");
            wb.Document.InvokeScript("setSize", args.ToArray());
        }

        /// <summary>
        /// 值和条码类型才可以选列名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type.Text == BQ_LX.变量.ToString() || cmb_type.Text == BQ_LX.条码.ToString())
            {
                cmb_field.Enabled = true;
            }
            else
            {
                cmb_field.SelectedIndex = -1;
                cmb_field.Enabled = false;
            }
        }

        /// <summary>
        /// 选中行，预览标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count < 1)
            {
                return;
            }

            if (wb.Document == null)
            {
                return;
            }

            DataGridViewRow dr = grid.SelectedRows[0];

            List<object> args = new List<object>();
            args.Add(dr.Cells[col_xh.Name].Value.ToString());
            args.Add(dr.Cells[col_tm.Name].Value.ToString());
            args.Add(dr.Cells[col_kh.Name].Value.ToString());
            args.Add(dr.Cells[col_pm.Name].Value.ToString());
            args.Add(dr.Cells[col_ys.Name].Value.ToString());
            args.Add(dr.Cells[col_cm.Name].Value.ToString());
            args.Add(dr.Cells[col_dpj.Name].Value.ToString());
            args.Add(dr.Cells[col_gys.Name].Value.ToString());
            args.Add(dr.Cells[col_gyskh.Name].Value.ToString());

            wb.Document.InvokeScript("setValue", args.ToArray());
        }
    }

    public enum BQ_LX:byte
    {
        文本=1,
        图片=2,
        变量=3,
        条码=4
    }
}
