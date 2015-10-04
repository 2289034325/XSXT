﻿using DB_CK;
using CKGL.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKGL
{
    public static class IDB
    {
        public static DBContext GetDB()
        {
            return new DBContext(Settings.Default.DBSERVER, Settings.Default.DBName, Settings.Default.DBUSER, Settings.Default.DBPSW, Settings.Default.DBPath);
        }
        public static string GetConn()
        {
            return string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};MultipleActiveResultSets=True", Settings.Default.DBSERVER, Settings.Default.DBName, Settings.Default.DBUSER, Settings.Default.DBPSW);
        }
    }
}
