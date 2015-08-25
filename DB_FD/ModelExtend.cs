using DB_FD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;

namespace DB_FD
{
    public partial class DBContext
    {
        private FDContext _db;

        private string _dbServer;
        private string _dbName;
        private string _dbPath;
        private string _dbUid;
        private string _dbPsw;

        public DBContext(string Server, string DBName, string User, string Psw, string dbPath)
        {
            string conn = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", Server, DBName, User, Psw);
            _dbServer = Server;
            _dbName = DBName;
            _dbPath = dbPath;
            _dbUid = User;
            _dbPsw = Psw;

            _db = new FDContext(conn);

            //此项会引起entity无法序列化的错误
            _db.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// 数据库初始化
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="v">当前运行需要的版本号</param>
        public void InitializeDatabase(int v)
        {
            if (!_db.Database.Exists())
            {
                //创建数据库
                createDB();

                //创建表
                sqlFile("SqlScript/tb.sql");

                //更新版本数据
                TVersion tv = new TVersion
                {
                    banben = v,
                    shengjishijian = DateTime.Now
                };

                _db.TVersions.Add(tv);

                //增加一个系统管理员
                TUser u = new TUser
                {
                    dengluming = "admin",
                    mima = Tool.CommonFunc.MD5_16("administrator"),
                    juese = (byte)Tool.FD.DBCONSTS.USER_XTJS.系统管理员,
                    yonghuming = "管理员",
                    charushijian = DateTime.Now,
                    xiuggaishijian = DateTime.Now,
                    beizhu = "",
                    zhuangtai = (byte)Tool.FD.DBCONSTS.USER_ZT.可用
                };
                _db.TUsers.Add(u);

                _db.SaveChanges();
            }
            else
            {
                int cv = GetDbVersion();
                if (cv > v)
                {
                    throw new MyException("数据库版本异常", null);
                }
                else if (cv < v)
                {
                    //备份
                    DBTool dt = new DBTool(string.Format("Data Source={0};Initial Catalog=master;User ID={1};Password={2};", _dbServer, _dbUid, _dbPsw));
                    string bkPath = _dbPath + "UPbak\\";
                    if (!Directory.Exists(bkPath))
                    {
                        Directory.CreateDirectory(bkPath);
                    }
                    string bkFile = bkPath + "v" + cv + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                    dt.BackUp(bkFile);

                    using (var dbContextTransaction = _db.Database.BeginTransaction())
                    {
                        try
                        {
                            cv++;
                            for (; cv <= v; cv++)
                            {
                                sqlFile("SqlScript/" + cv + ".sql");
                            }
                            //更新版本数据
                            TVersion tv = new TVersion
                            {
                                banben = v,
                                shengjishijian = DateTime.Now
                            };

                            _db.TVersions.Add(tv);

                            _db.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }

        private void sqlFile(string file)
        {
            string sql = File.ReadAllText(file, Encoding.Default);
            //ExecuteSqlCommand不支持GO,因此，分隔开，变为多个命令遍历执行
            string[] cmms = sql.Split(new string[] { "GO\r\n","\r\nGO" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string cmm in cmms)
            {
                if (string.IsNullOrEmpty(cmm) || string.IsNullOrWhiteSpace(cmm))
                {
                    continue;
                }

                _db.Database.ExecuteSqlCommand(cmm);
            }
        }

        private void sqlString(string sql)
        {
 
        }

        private void createDB()
        {
            DBTool dt = new DBTool(string.Format("Data Source={0};Initial Catalog=master;User ID={1};Password={2};", _dbServer, _dbUid, _dbPsw));
            string file = "SqlScript/db.sql";
            string sql = File.ReadAllText(file, Encoding.Default);
            if (!Directory.Exists(_dbPath))
            {
                Directory.CreateDirectory(_dbPath);
            }
            sql = sql.Replace("@DBPath", _dbPath).Replace("@DBName", _dbName);
            dt.CreateDatabase(sql);
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
