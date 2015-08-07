using DB_CK.Migrations;
using DB_CK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;

namespace DB_CK
{
    public partial class DBContext
    {
        private CKContext _db;
        public DBContext(string Server,string DBName ,string User,string Psw)
        {
            string conn = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", Server, DBName, User, Psw);

            _db = new CKContext(conn);

            //此项会引起entity无法序列化的错误
            _db.Configuration.ProxyCreationEnabled = false;
        }

        public static void InitializeDatabase(string conn)
        {
            using (var ck = new CKContext(conn))
            {
                if (!ck.Database.Exists())
                {
                    throw new MyException("数据库不存在", null);
                }
            }
        }
    }
}

namespace DB_CK.Models
{
    public partial class CKContext : DbContext
    {
        /// <summary>
        /// 指定连接字符串
        /// </summary>
        /// <param name="conn">数据库连接</param>
        public CKContext(string conn)
            : base(conn)
        {
        }
    }    
}

