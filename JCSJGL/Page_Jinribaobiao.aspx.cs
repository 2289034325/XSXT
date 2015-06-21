using DB_JCSJ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_Jinribaobiao : System.Web.UI.Page
    {
        public string Trs;
        protected void Page_Load(object sender, EventArgs e)
        {
            DBContext db = new DBContext();
            int recordCount;
            TXiaoshou[] xss = db.GetXiaoshousByCond(null, DateTime.Now.Date, DateTime.Now.Date, null, null, null, null, out recordCount);
            var data = xss.GroupBy(r => r.TFendian.dianming).Select(r => new
            {
                fd = r.Key,
                xsl = r.Sum(g => g.shuliang),
                xse = r.Sum(g => decimal.Round(g.danjia * g.shuliang * g.zhekou / 10 - g.moling, 2)),
                lr = r.Sum(g => decimal.Round(g.danjia * g.shuliang * g.zhekou / 10 - g.moling - g.TTiaoma.jinjia * g.shuliang, 2))
            });

            foreach (var d in data)
            {
                Trs += "<div>"
                    + "<label class='lbl_dm'>" + d.fd + "</label><br/>"
                    + "<label>销售量：" + d.xsl + "</label><br/>"
                    + "<label>销售额：" + d.xse + "</label><br/>"
                    + "<label>**利润：" + d.lr + "</label><br/>" 
                    +"<hr/></div>";
            }
        }
    }
}