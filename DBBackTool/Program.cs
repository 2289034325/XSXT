using Aliyun.OpenServices.OpenStorageService;
using DBBackTool.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBBackTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                //直接执行备份
                try
                {
                    DoBackUp.doBackUp();
                }
                catch (Exception ex)
                { }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Control.CheckForIllegalCrossThreadCalls = false;
                Application.Run(new Form_Main());
            }
        }
    }

    static class DoBackUp
    {
        /// <summary>
        /// 执行备份任务
        /// </summary>
        public static void doBackUp()
        {
            //备份
            string file = dbBack();

            if (Settings.Default.ALI)
            {
                //上传到阿里云
                aliUpload(file);
            }
        }

        /// <summary>
        /// 数据库备份
        /// </summary>
        /// <returns></returns>
        private static string dbBack()
        {
            string dbServer = Settings.Default.DBServer;
            string dbName = Settings.Default.DBName;
            string dbUid = Settings.Default.DBUid;
            string dbPsw = Settings.Default.DBPsw;
            string localPath = Settings.Default.LocalPath;

            string connStr = "data source=" + dbServer + ";initial catalog=" + dbName + ";user id=" + dbUid + ";password=" + dbPsw;

            string folderName = DateTime.Now.ToString("yyyyMMdd");
            string filePath = localPath + folderName + "\\";
            string fileName = dbName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sqlStmt = String.Format("BACKUP DATABASE " + dbName + " TO DISK='{0}'", filePath + fileName);
                SqlCommand cmd = new SqlCommand(sqlStmt, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return filePath + fileName;
        }

        /// <summary>
        /// 上传到阿里云
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="file"></param>
        private static void aliUpload(string file)
        {
            string[] ss = file.Split(new char[]{'\\'});
            string folderName = ss[ss.Length - 2] + "/";
            string fileName = ss[ss.Length - 1];
            
            string accessId = Settings.Default.AliKeyId;
            string accessKey = Settings.Default.AliKey;
            string bucketName = Settings.Default.AliBucketName;
            string endpoint = Settings.Default.AliEndpoint;
            string key = Settings.Default.AliPath + folderName + fileName;

            OssClient client = new OssClient(endpoint, accessId, accessKey);
            client.PutObject(bucketName, key, file);
        }
    }
}
