using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_FDKucunMX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //取得库存记录ID
                int kcid = int.Parse(Request["id"]);
                getMX(kcid);
            }
        }

        private void getMX(int jcid)
        { 
            DBContext db = new DBContext();
            TFendianKucunMX[] amxs = db.GetFDKucunMXsByKcId(jcid);

            var mxs = amxs.Select(r => new 
            {
                r.TTiaoma.tiaoma,
                r.TTiaoma.TKuanhao.kuanhao,
                r.TTiaoma.gyskuanhao,
                leixing = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.TTiaoma.TKuanhao.leixing).ToString(),
                r.TTiaoma.TKuanhao.pinming,
                r.TTiaoma.yanse,
                r.TTiaoma.chima,
                r.TTiaoma.jinjia,
                r.TTiaoma.shoujia,
                r.shuliang
            });

            grid_mx.DataSource = Tool.CommonFunc.LINQToDataTable(mxs);
            grid_mx.DataBind();
        }        
    }
}