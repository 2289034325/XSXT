using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_FD
{
    public partial class FDEntities : DbContext
    {
        /// <summary>
        /// 使用配置文件中指定名称的连接字符串
        /// </summary>
        /// <param name="connName"></param>
        public FDEntities(string connName):base("name="+connName)
        {
 
        }

        /// <summary>
        /// 指定服务器，用户和密码
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="User"></param>
        /// <param name="Psw"></param>
        public FDEntities(string Server,string User,string Psw)
            : base(new System.Data.EntityClient.EntityConnectionStringBuilder
            {
                Metadata = "res://*",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder
                {
                    InitialCatalog = "FD",
                    DataSource = Server,
                    IntegratedSecurity = false,
                    UserID = User,                
                    Password = Psw,               
                }.ConnectionString
            }.ConnectionString)
        {
        }
    }
}
