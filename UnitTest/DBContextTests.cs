using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_JCSJ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB_JCSJ.Models;
namespace DB_JCSJ.Tests
{
    [TestClass()]
    public class DBContextTests
    {
        [TestMethod()]
        public void GetFDJinhuoshujuTest()
        {
            DB_JCSJ.DBContext db = new DBContext();
            try
            {
                TCangkuFahuoFendian[] fs = db.GetFDJinhuoshuju(1);
            }
            catch (Exception ex)
            {
 
            }
            //Assert.Fail();
        }
    }
}
