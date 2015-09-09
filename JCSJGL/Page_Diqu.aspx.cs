using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_Diqu : MyPage
    {
        public Page_Diqu()
        {
            _PageName = PageName.地区编码;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                DBContext db = new DBContext();
                VDiqu[] dqs = db.GetAllDiqus();

                VDiqu[] dqs0 = dqs.Where(r => r.fid == null).ToArray();
                foreach (VDiqu d in dqs0)
                {
                    TreeNode nd = new TreeNode(d.mingcheng, d.id.ToString());
                    nd.SelectAction = TreeNodeSelectAction.SelectExpand;
                    trv.Nodes.Add(nd);
                    appendChildNode(nd, dqs);                    
                }
            }      
        }

        private void appendChildNode(TreeNode nd, VDiqu[] dqs)
        {
            int id = int.Parse(nd.Value);
            VDiqu[] cs = dqs.Where(r => r.fid == id).ToArray();
            if (cs.Count() == 0)
            {
                return;
            }

            foreach (VDiqu d in cs)
            {
                TreeNode cnd = new TreeNode(d.mingcheng, d.id.ToString());
                cnd.SelectAction = TreeNodeSelectAction.SelectExpand;
                nd.ChildNodes.Add(cnd);
                appendChildNode(cnd, dqs);  
            }
        }

        /// <summary>
        /// 增加一个根节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_addRoot_Click(object sender, EventArgs e)
        {
            string mc = txb_mc.Text.Trim();
            if (string.IsNullOrEmpty(mc))
            {
                throw new MyException("名称不能为空白", null);
            }
            TDiqu d = new TDiqu
            {
                fid = null,
                mingcheng = mc,
                lsmingcheng = mc,
                xiugaishijian = DateTime.Now
            };

            DBContext db = new DBContext();
            TDiqu nd = db.InsertDiqu(d);
            TreeNode tnd = new TreeNode(nd.mingcheng, nd.id.ToString());
            trv.Nodes.Add(tnd);
        }

        /// <summary>
        /// 增加一个子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_addChild_Click(object sender, EventArgs e)
        {
            int fid = 0;
            if (int.TryParse(trv.SelectedValue, out fid))
            {
                string mc = txb_mc.Text.Trim();
                if (string.IsNullOrEmpty(mc))
                {
                    throw new MyException("名称不能为空白", null);
                }
                TDiqu d = new TDiqu
                {
                    fid = fid,
                    mingcheng = mc,
                    lsmingcheng = mc,
                    xiugaishijian = DateTime.Now
                };

                DBContext db = new DBContext();
                TDiqu nd = db.InsertDiqu(d);
                TreeNode tnd = new TreeNode(nd.mingcheng, nd.id.ToString());
                trv.SelectedNode.ChildNodes.Add(tnd);
            }
            else
            {
                throw new MyException("请先选中一个节点", null);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_delete_Click(object sender, EventArgs e)
        {
             int id = 0;
             if (int.TryParse(trv.SelectedValue, out id))
             {
                 DBContext db = new DBContext();
                 db.DeleteDiqu(id);

                 trv.Nodes.Remove(trv.SelectedNode);
             }
             else
             {
                 throw new MyException("请先选中一个节点", null);
             }
        }

        /// <summary>
        /// 修改节点名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            string mc = txb_mc.Text.Trim();
            if (string.IsNullOrEmpty(mc))
            {
                throw new MyException("名称不能为空白", null);
            }

            int id = 0;
            if (int.TryParse(trv.SelectedValue, out id))
            {
                DBContext db = new DBContext();
                db.UpdateDiqu(id, mc);

                trv.SelectedNode.Text = mc;
            }
            else
            {
                throw new MyException("请先选中一个节点", null);
            }
        }
    }
}