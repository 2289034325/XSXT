using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.UI.WebControls;
using Tool.DB.JCSJ;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MD5_16()
        {
            Tool.CommonFunc.MD5_16("a");
        }

        [TestMethod]
        public void Login()
        {
            WCF.Service_GLClient client = new WCF.Service_GLClient();
           Tool.DB.JCSJ.TUser u = client.Login("a", Tool.CommonFunc.MD5_16("a"));
            //Tool.DB.JCSJ.TUser u = client.Logint();
        }

        [TestMethod]
        public void InitComb()
        {
            Tool.CommonFunc.InitCombbox(new DropDownList(), typeof(Tool.DB.JCSJ.CONSTS.USER_XTJS));
        }

        [TestMethod]
        public void GetFendians()
        {
            OPT db = new OPT();
            TFendian[] fs = db.GetAllFendians();
        }
    }
}
