using DB_FD;
using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDXS
{
    public static class IDB
    {
        public static DBContext GetDB()
        {
            return new DBContext(Settings.Default.DBSERVER, Settings.Default.DBUSER, Settings.Default.DBPSW);
        }
    }
}
