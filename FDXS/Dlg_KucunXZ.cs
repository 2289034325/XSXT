﻿using DB_FD;
using FDXS.Properties;
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
    public partial class Dlg_KucunXZ : Form
    {
        private TUser _user;
        public TKucunXZ XZ;
        public Dlg_KucunXZ(TUser user)
        {
            InitializeComponent();
            _user = user;
            XZ = new TKucunXZ();
        }


        /// <summary>
        /// 增加一个修正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string tmh = txb_tmh.Text.Trim();
            string ssl = txb_sl.Text.Trim();
            short sl;
            if (!short.TryParse(ssl, out sl))
            {
                MessageBox.Show("数量必须是整数");
                return;
            }

            //检查该条码号是否存在
            DBContext db = new DBContext();
            TTiaoma tm = db.GetTiaomaByTmh(tmh);
            if (tm == null)
            {
                MessageBox.Show("条码号不存在");
                return;
            }

            //插入一个修正记录
            XZ = db.InsertKucunXZ(new TKucunXZ
            {
                tiaomaid = tm.id,
                shuliang = sl,
                caozuorenid = _user.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            });
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Zhuce_Load(object sender, EventArgs e)
        {

        }

        
    }
}
