using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJGL
{
    public partial class Page_Cangku : MyPage
    {
        public Page_Cangku()
        {
            _PageName = PageName.仓库信息;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载所有仓库信息
                loadCangkus();
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteCangku(id);
                }

                //操作后清除操作标志
                hid_opt.Value = "";
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void deleteCangku(int id)
        {
            //检查权限
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            DBContext db = new DBContext();
            TCangku oc = db.GetCangkuById(id);
            if (oc.jmsid != _LoginUser.jmsid)
            {
                throw new MyException("非法操作，无法删除此仓库");
            }
            db.DeleteCangku(id);

            loadCangkus();
        }

        /// <summary>
        /// 加载仓库信息
        /// </summary>
        private void loadCangkus()
        {
            DBContext db = new DBContext();
            TCangku[] cs =null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                cs = db.GetCangkus();
                grid_cangku.Columns.Insert(1, new BoundField()
                {
                    HeaderText = "加盟商",
                    DataField = "jiamengshang"
                });
            }
            else
            {
                cs = db.GetCangkusByJmcId(_LoginUser.jmsid);
            }

            var dfs = cs.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TJiamengshang.mingcheng,
                mingcheng = r.mingcheng,
                dizhi = r.dizhi,
                lianxiren = r.lianxiren,
                dianhua = r.dianhua,
                beizhu = r.beizhu,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.mingcheng + "','" + r.dizhi + "','" + r.lianxiren + "','" + r.dianhua + "','" + r.beizhu + "'"
            });

            grid_cangku.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_cangku.DataBind();
        }


        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            TCangku f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = _LoginUser.id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            TCangku oc = db.GetCangkuById(f.id);
            if (oc.jmsid != _LoginUser.jmsid)
            {
                throw new MyException("非法操作，无法修改该仓库的信息");
            }
            db.UpdateCangku(f);

            loadCangkus();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private TCangku getEditInfo()
        {
            string mc = txb_mc.Text.Trim();
            string dz = txb_dz.Text.Trim();
            string lxr = txb_lxr.Text.Trim();
            string dh = txb_dh.Text.Trim();
            string bz = txb_bz.Text.Trim();

            TCangku f = new TCangku
            {
                mingcheng = mc,
                dizhi = dz,
                lianxiren = lxr,
                dianhua = dh,
                beizhu = bz
            };

            return f;
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            TCangku f = getEditInfo();
            f.jmsid = _LoginUser.jmsid;
            f.caozuorenid = _LoginUser.id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            //限制可增加的仓库数量
            TCangku[] cs = db.GetCangkusByJmcId(_LoginUser.jmsid);
            if (cs.Count() >= _LoginUser.TJiamengshang.cangkushu)
            {
                throw new MyException("拥有的仓库数量已到上限，如有需要增加更多仓库请联系系统管理员");
            }
            db.InsertCangku(f);

            loadCangkus();
        }
    }
}