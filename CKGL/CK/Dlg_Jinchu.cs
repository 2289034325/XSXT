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

            Churuku = null;
        }

        public Dlg_Jinchu(TChuruku Cr)
        {
            InitializeComponent();

            Churuku = Cr;
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

            int? jmsid = null;
            decimal? zk = null;
            if (cmb_jms.SelectedValue != null)
            {
                jmsid = (int)cmb_jms.SelectedValue;
            }
            if (!string.IsNullOrEmpty(txb_zk.Text.Trim()))
            {
                zk = decimal.Parse(txb_zk.Text.Trim());
            }
            if (zk != null)
            {
                if (zk <= 0 || zk > 10)
                {
                    MessageBox.Show("折扣范围为(0,10]");
                    return;
                }
            }

            string bz = txb_bz.Text.Trim();

            if (fx == (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进)
            {
                if (lyqx == (byte)Tool.JCSJ.DBCONSTS.LYQX_CK.丢弃)
                {
                    MessageBox.Show("进货的来源不能是[丢弃、其他]");
                    return;
                }
            }
            else
            {
                if (lyqx == (byte)Tool.JCSJ.DBCONSTS.LYQX_CK.新货)
                {
                    MessageBox.Show("出货的去向不能是[新货]");
                    return;
                }

                //出货给加盟商的时候必须有个折扣
                if (lyqx == (byte)Tool.JCSJ.DBCONSTS.LYQX_CK.加盟商)
                {
                    if (jmsid == null)
                    {
                        MessageBox.Show("请选择一个加盟商");
                        return;
                    }
                }
                else
                {
                    //来源去向不是[加盟商]的时候，不允许选择任何加盟商
                    jmsid = null;
                }
            }

            TChuruku cr = new TChuruku
            {
                picima = null,
                zhekou = zk,
                jmsid =jmsid,
                beizhu = bz,
                queding = false,
                caozuorenid = RuntimeInfo.LoginUser_CK.id,
                fangxiang = fx,               
                laiyuanquxiang = lyqx,
                shangbaoshijian = null,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            };

            DBContext db = IDB.GetDB();
            if (Churuku == null)
            {
                Churuku = db.InsertChuruku(cr);
            }
            else
            {
                cr.id = Churuku.id;
                db.UpdateChuruku(cr);
            }

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

            Tool.CommonFunc.InitCombbox(cmb_lyqx, typeof(Tool.JCSJ.DBCONSTS.LYQX_CK));
            cmb_lyqx.SelectedIndex = -1;

            DBContext db = IDB.GetDB();
            TJiamengshang[] jmses = db.GetJiamengshangs(true);
            cmb_jms.DataSource = jmses;
            cmb_jms.DisplayMember = "mingcheng";
            cmb_jms.ValueMember = "id";
            cmb_jms.SelectedIndex = -1;

            if (Churuku != null)
            {
                cmb_fx.SelectedValue = Churuku.fangxiang;
                cmb_lyqx.SelectedValue = Churuku.laiyuanquxiang;

                if (Churuku.jmsid != null)
                {
                    cmb_jms.SelectedValue = Churuku.jmsid;
                }

                txb_zk.Text = Churuku.zhekou.ToString();
                txb_bz.Text = Churuku.beizhu;
            }
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
                if (lyqx == (byte)Tool.JCSJ.DBCONSTS.LYQX_CK.加盟商)
                {
                    cmb_jms.SelectedIndex = -1;
                    cmb_jms.Enabled = true;
                }
                else
                {
                    cmb_jms.SelectedIndex = -1;
                    cmb_jms.Enabled = false;
                }
            }
        }   
    }
}
