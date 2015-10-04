using DB_CK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;

namespace DB_CK
{
    public partial class DBContext
    {
        private CKContext _db;

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

            _db = new CKContext(conn);

            //此项会引起entity无法序列化的错误
            _db.Configuration.ProxyCreationEnabled = false;
        }

        public void InitializeDatabase(int v)
        {
            DBTool dt = new DBTool(string.Format("Data Source={0};Initial Catalog=master;User ID={1};Password={2};", _dbServer, _dbUid, _dbPsw));
            if (!_db.Database.Exists())
            {
                //创建数据库
                dt.CreateDatabase(_dbPath, _dbName);

                //创建表
                dt.SqlFile(_db,"SqlScript/0.sql");

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
                    juese = (byte)Tool.CK.DBCONSTS.USER_XTJS.系统管理员,
                    yonghuming = "管理员",
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now,
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
                    string bkPath = _dbPath + "UPbak\\";
                    string fName = "v" + cv + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                    dt.BackUp(bkPath,fName);

                    using (var dbContextTransaction = _db.Database.BeginTransaction())
                    {
                        try
                        {
                            cv++;
                            for (; cv <= v; cv++)
                            {
                                //sqlFile("SqlScript/" + cv + ".sql");
                                dt.SqlFile(_db,"SqlScript/" + cv + ".sql");
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

