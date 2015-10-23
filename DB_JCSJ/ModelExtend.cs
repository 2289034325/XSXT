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
                return decimal.Round(shoujia * shuliang * zhekou / 10 - moling, 2);
            }
        }

        [NotMapped]
        public decimal lirun
        {
            get
            {
                return decimal.Round(jine - jinjia * shuliang, 2);
            }            
        }
    }
}
