using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
