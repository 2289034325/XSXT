using DB_FD.Migrations;
using DB_FD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;

namespace DB_FD
{
    public partial class DBContext
    {
        private FDContext _db;
        public DBContext(string Server,string DBName ,string User,string Psw)
        {
            string conn = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", Server, DBName, User, Psw);

            _db = new FDContext(conn);

            //此项会引起entity无法序列化的错误
            _db.Configuration.ProxyCreationEnabled = false;
        }

        public static void InitializeDatabase(string conn)
        {
            using (var fd = new FDContext(conn))
            {
                if (!fd.Database.Exists())
                {
                    throw new MyException("数据库不存在", null);
                }
            }
        }
    }
}

namespace DB_FD.Models
{
    public partial class FDContext:DbContext
    {
        /// <summary>
        /// 指定连接字符串
        /// </summary>
        /// <param name="conn">数据库连接</param>
        public FDContext(string conn)
            : base(conn)
        {
        }        
    }

    /// <summary>
    /// 特殊的计算列
    /// </summary>
    public partial class TXiaoshou
    {
        [NotMapped]
        public decimal jine
        {
            get 
            {
                return decimal.Round(danjia * shuliang * zhekou / 10 - moling, 2);
            }
        }
    }
}
