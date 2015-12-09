using DB_FD;
using DB_FD.Models;
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

namespace FDXS
{
    public partial class Dlg_Jinchu : Form
    {
        public TJinchuhuo Jinchu;
        public Dlg_Jinchu()
        {
            InitializeComponent();

            Jinchu = null;
        }

        public Dlg_Jinchu(TJinchuhuo Cr)
        {
            InitializeComponent();

            Jinchu = Cr;
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
            
            string bz = txb_bz.Text.Trim();

            if (fx == (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进)
            {
                if (lyqx == (byte)Tool.JCSJ.DBCONSTS.LYQX_CK.丢弃)
                {
                    MessageBox.Show("进货的来源不能是[丢弃]");
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
            }

            TJinchuhuo cr = new TJinchuhuo
            {
                fangxiang = fx,
                laiyuanquxiang = lyqx,
                picima = null,
                beizhu = bz,
                queding = false,
                caozuorenid = RuntimeInfo.LoginUser.id,
                shangbaoshijian = null,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            };

            DBContext db = IDB.GetDB();
            if (Jinchu == null)
            {
                Jinchu = db.InsertJinchuhuo(cr);
                Jinchu = db.GetJinchuhuoById(Jinchu.id);
            }
            else
            {
                cr.id = Jinchu.id;
                db.UpdateJinchuhuo(cr);
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

            Tool.CommonFunc.InitCombbox(cmb_lyqx, typeof(Tool.JCSJ.DBCONSTS.LYQX_FD));
            cmb_lyqx.SelectedIndex = -1;

            if (Jinchu != null)
            {
                cmb_fx.SelectedValue = Jinchu.fangxiang;
                cmb_lyqx.SelectedValue = Jinchu.laiyuanquxiang;

                txb_bz.Text = Jinchu.beizhu;
            }
        }
    }
}
