using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_JCSJ
{
    public partial class DBContext
    {
        private JCSJContext _db;
        public DBContext()
        {
            _db = new JCSJContext();
            //此项会引起entity无法序列化的错误
            _db.Configuration.ProxyCreationEnabled = false;
        }
    }
}

namespace DB_JCSJ.Models
{
    public partial class FDContext : DbContext
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
