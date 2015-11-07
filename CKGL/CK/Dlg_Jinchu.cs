using CKGL.Properties;
using DB_CK;
using DB_CK.Models;
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

namespace CKGL.CK
{
    public partial class Dlg_Jinchu : Form
    {
        public TChuruku Churuku;
        public Dlg_Jinchu()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 设置进出选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)cmb_fx.SelectedValue))
            {
                MessageBox.Show("请选择进货还是出货");
                return;
            }
            byte fx = byte.Parse((string)cmb_fx.SelectedValue);
            if (string.IsNullOrEmpty(cmb_lyqx.SelectedValue.ToString()))
            {
                MessageBox.Show("请选择进出货的来源或者去向");
                return;
            }
            byte lyqx = byte.Parse(cmb_lyqx.SelectedValue.ToString());

            int? ckid = null;
            int? fdid = null;
            int? jmsid = null;
            decimal? zk = null;
            if (!string.IsNullOrEmpty((string)cmb_ck.SelectedValue))
            {
                ckid = int.Parse(cmb_ck.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty((string)cmb_fd.SelectedValue))
            {
                fdid = int.Parse(cmb_fd.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty((string)cmb_jms.SelectedValue))
            {
                jmsid = int.Parse(cmb_jms.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty(txb_zk.Text.Trim()))
            {
                zk = decimal.Parse(txb_zk.Text.Trim());
            }

            string bz = txb_bz.Text.Trim();

            if (fx == (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进)
            {
                if (lyqx == (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.丢弃 || lyqx == (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.退货)
                {
                    MessageBox.Show("进货的来源不能是[丢弃、退货]");
                    return;
                }
            }
            else
            {
                if (lyqx == (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.新货)
                {
                    MessageBox.Show("出货的去向不能是[新货]");
                    return;
                }

                //出货给加盟商的时候必须有个折扣
                if (lyqx == (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.加盟商)
                {
                    if (zk == null)
                    {
                        MessageBox.Show("出货给加盟商，必须填写一个折扣，范围为(0,10]");
                        return;
                    }
                    else if (zk <= 0 || zk > 10)
                    {
                        MessageBox.Show("折扣范围为(0,10]");
                        return;
                    }
                }
            }

            TChuruku cr = new TChuruku
            {
                beizhu = bz,
                caozuorenid = RuntimeInfo.LoginUser_CK.id,
                fangxiang = fx,               
                laiyuanquxiang = lyqx,
                shangbaoshijian = null,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            };

            DBContext db = IDB.GetDB();
            Churuku = db.InsertChuruku(cr);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Fendian_Load(object sender, EventArgs e)
        {
            Tool.CommonFunc.InitCombbox(cmb_fx, typeof(Tool.JCSJ.DBCONSTS.JCH_FX));
            cmb_fx.SelectedIndex = -1;

            Tool.CommonFunc.InitCombbox(cmb_lyqx, typeof(Tool.JCSJ.DBCONSTS.JCH_LYQX));
            cmb_lyqx.SelectedIndex = -1;

            //if (RuntimeInfo.AllCks == null)
            //{
            //    //加载仓库、分店、子加盟商信息
            //    new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            //        {
            //            try
            //            {
            //                CKGL.JCSJData.TCangku[] cks = JCSJWCF.GetCangkus();
            //                CKGL.JCSJData.TFendian[] fds = JCSJWCF.GetFendians();
            //                CKGL.JCSJData.TJiamengshangGX[] jmses = JCSJWCF.GetZiJiamengshangs();

            //                RuntimeInfo.AllCks = cks.Where(r => r.id != Settings.Default.CKID).ToDictionary(k => k.id.ToString(), v => v.mingcheng);
            //                RuntimeInfo.AllFds = fds.ToDictionary(k => k.id.ToString(), v => v.dianming);
            //                RuntimeInfo.AllJmses = jmses.ToDictionary(k => k.jmsid.ToString(), v => v.bzmingcheng);
            //            }
            //            catch (Exception ex)
            //            {
            //                Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
            //                ShowMsg(ex.Message, true);
            //                Close();
            //            }

            //        }, true).Start();
            //}

            //Tool.CommonFunc.InitCombbox(cmb_ck, RuntimeInfo.AllCks);
            //cmb_ck.SelectedIndex = -1;
            //Tool.CommonFunc.InitCombbox(cmb_fd, RuntimeInfo.AllFds);
            //cmb_fd.SelectedIndex = -1;
            //Tool.CommonFunc.InitCombbox(cmb_jms, RuntimeInfo.AllJmses);
            //cmb_jms.SelectedIndex = -1;
        }

        /// <summary>
        /// 来源去向选择后，决定其他下拉框是否可选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_lyqx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_lyqx.SelectedValue != null)
            {
                byte lyqx = byte.Parse(cmb_lyqx.SelectedValue.ToString());
                if (lyqx == (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.仓库)
                {
                    cmb_fd.SelectedIndex = -1;
                    cmb_fd.Enabled = false;
                    cmb_jms.SelectedIndex = -1;
                    cmb_jms.Enabled = false;
                    txb_zk.Enabled = false;

                    cmb_ck.SelectedIndex = -1;
                    cmb_ck.Enabled = true;
                }
                else if (lyqx == (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.分店)
                {
                    cmb_ck.SelectedIndex = -1;
                    cmb_ck.Enabled = false;
                    cmb_jms.SelectedIndex = -1;
                    cmb_jms.Enabled = false;
                    txb_zk.Enabled = false;

                    cmb_fd.SelectedIndex = -1;
                    cmb_fd.Enabled = true;
                }
                else if (lyqx == (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.加盟商)
                {
                    cmb_fd.SelectedIndex = -1;
                    cmb_fd.Enabled = false;
                    cmb_ck.SelectedIndex = -1;
                    cmb_ck.Enabled = false;

                    cmb_jms.SelectedIndex = -1;
                    cmb_jms.Enabled = true;
                    byte fx = byte.Parse(cmb_fx.SelectedValue.ToString());
                    if (fx == (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进)
                    {
                        txb_zk.Text = "";
                        txb_zk.Enabled = false;
                    }
                    else if (fx == (byte)Tool.JCSJ.DBCONSTS.JCH_FX.出)
                    {
                        txb_zk.Text = "";
                        txb_zk.Enabled = true;
                    }
                    else
                    {
                        txb_zk.Text = "";
                        txb_zk.Enabled = false;
                    }
                }
                else
                {
                    cmb_fd.SelectedIndex = -1;
                    cmb_fd.Enabled = false;
                    cmb_ck.SelectedIndex = -1;
                    cmb_ck.Enabled = false;

                    cmb_jms.SelectedIndex = -1;
                    cmb_jms.Enabled = false;
                    txb_zk.Enabled = false;
                }
            }
        }   
    }
}
