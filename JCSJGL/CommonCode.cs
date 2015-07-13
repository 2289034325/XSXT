using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JCSJGL
{
    public class MyException:Exception
    {
        public MyException(string msg)
            : base(msg)
        {
 
        }
    }
}