using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tool
{
    public static class CommonFunc
    {

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns></returns>
        public static string MD5_16(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }

            MD5 md5 = new MD5CryptoServiceProvider();
            string mmd5 = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");

            return mmd5.Substring(8, 16);
        }

        /// <summary>
        /// 将匿名对象数组转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static DataTable LINQToDataTable<T>(IEnumerable<T> array)
        {
            var ret = new DataTable();
            foreach (PropertyDescriptor dp in TypeDescriptor.GetProperties(typeof(T)))
            {
                Type colType = dp.PropertyType;
                string colName = dp.Name;
                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                    == typeof(Nullable<>)))
                {
                    colType = colType.GetGenericArguments()[0];
                }

                ret.Columns.Add(colName, colType);

            }

            foreach (T item in array)
            {
                var Row = ret.NewRow();
                foreach (PropertyDescriptor dp in TypeDescriptor.GetProperties(typeof(T)))
                {
                    Row[dp.Name] = dp.GetValue(item) == null ? DBNull.Value : dp.GetValue(item);
                }
                ret.Rows.Add(Row);
            }
            return ret;
        }


        /// <summary>
        /// 将枚举转换成字典
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDicFromEnum(Type t)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Array vs = Enum.GetValues(t);
            foreach (Enum v in vs)
            {
                dic.Add(Enum.GetName(t, v), Convert.ToByte(v).ToString());
            }

            return dic;
        }

        /// <summary>
        /// 将枚举类型做成一个DataTable
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DataTable GetTableFromEnum(Type type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            Array vs = Enum.GetValues(type);
            foreach (Enum v in vs)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = Enum.GetName(type, v);
                dr["Value"] = Convert.ToInt16(v).ToString();
                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        /// <param name="Cmb"></param>
        /// <param name="Items"></param>
        public static void InitCombbox(ComboBox Cmb,Type type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value",typeof(string));
            Array vs = Enum.GetValues(type);
            foreach (Enum v in vs)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = Enum.GetName(type, v);
                dr["Value"] = Convert.ToInt16(v).ToString();
                dt.Rows.Add(dr);
            }

            Cmb.DisplayMember = "Text";
            Cmb.ValueMember = "Value";
            Cmb.DataSource = dt;
        }
        public static void InitCombbox(ComboBox Cmb, Dictionary<string, string> dic)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            foreach (KeyValuePair<string, string> p in dic)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = p.Value;
                dr["Value"] = p.Key;
                dt.Rows.Add(dr);
            }

            Cmb.DisplayMember = "Text";
            Cmb.ValueMember = "Value";
            Cmb.DataSource = dt;
        }
        public static void InitCombbox(ComboBox Cmb, object[] Items, string TextField, string ValueField)
        {
            if (Items.Length < 1)
            {
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");

            Type type = Items[0].GetType();
            System.Reflection.PropertyInfo tInfo = type.GetProperty(TextField);
            System.Reflection.PropertyInfo vInfo = type.GetProperty(ValueField);
            foreach (object o in Items)
            {
                string text = tInfo.GetValue(o, null).ToString();
                string value = vInfo.GetValue(o, null).ToString();

                DataRow dr = dt.NewRow();
                dr["Text"] = text;
                dr["Value"] = value;
                dt.Rows.Add(dr);
            }

            Cmb.DisplayMember = "Text";
            Cmb.ValueMember = "Value";
            Cmb.DataSource = dt;
        }
        public static void InitDropDownList(DropDownList Cmb, Dictionary<string,string> dic)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            foreach (KeyValuePair<string, string> p in dic)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = p.Value;
                dr["Value"] = p.Key;
                dt.Rows.Add(dr);
            }

            Cmb.DataTextField = "Text";
            Cmb.DataValueField = "Value";
            Cmb.DataSource = dt;
            Cmb.DataBind();
        }
        public static void InitDropDownList(DropDownList Cmb, Type type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            Array vs = Enum.GetValues(type);
            foreach (Enum v in vs)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = Enum.GetName(type, v);
                dr["Value"] = Convert.ToInt16(v).ToString();
                dt.Rows.Add(dr);
            }

            Cmb.DataTextField = "Text";
            Cmb.DataValueField = "Value";
            Cmb.DataSource = dt;
            Cmb.DataBind();            
        }
        public static void InitDropDownList(DropDownList Cmb, object[] Items, string TextField, string ValueField)
        {
            if (Items.Length < 1)
            {
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");

            Type type = Items[0].GetType();
            System.Reflection.PropertyInfo tInfo = type.GetProperty(TextField);
            System.Reflection.PropertyInfo vInfo = type.GetProperty(ValueField);
            foreach (object o in Items)
            {
                string text = tInfo.GetValue(o, null).ToString();
                string value = vInfo.GetValue(o, null).ToString();

                DataRow dr = dt.NewRow();
                dr["Text"] = text;
                dr["Value"] = value;
                dt.Rows.Add(dr);
            }

            Cmb.DataTextField = "Text";
            Cmb.DataValueField = "Value";
            Cmb.DataSource = dt;
            Cmb.DataBind();            
        }

        /// <summary>
        /// 获取机器硬件特征码
        /// </summary>
        /// <returns></returns>
        public static string GetJQM()
        {
            string jqm = "";

            //获取网卡硬件地址
            string mac = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    mac = mo["MacAddress"].ToString();
                    break;
                }
            }
            jqm += mac;

            //cpu序列号
            string cpuInfo = "";
            mc = new ManagementClass("Win32_Processor");
            moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
            }
            jqm += cpuInfo;

            //硬盘序列号
            mc = new ManagementClass("Win32_PhysicalMedia");       
            moc = mc.GetInstances();
            string dskInfo = "";
            foreach( ManagementObject mo in moc )     
            {
                dskInfo = mo.Properties["SerialNumber"].Value.ToString();    
                break;
            }
            jqm += dskInfo;

            //主板序号
            mc = new ManagementClass("Win32_BaseBoard");   
            moc = mc.GetInstances();
            string mbdInfo = null;
            foreach( ManagementObject mo in moc )    
            {
                mbdInfo = mo.Properties["SerialNumber"].Value.ToString();   
                break;
            }
            jqm += mbdInfo;


            return jqm;
        }

        /// <summary>
        /// 检测是否是正常的手机号
        /// </summary>
        /// <param name="sjh"></param>
        /// <returns></returns>
        public static bool IsTelNum(string sjh)
        {
            //电信手机号码正则        
            string dianxin = @"^1[3578][01379]\d{8}$";        
            Regex dReg = new Regex(dianxin);        
            //联通手机号正则        
            string liantong = @"^1[34578][01256]\d{8}$";        
            Regex tReg = new Regex(liantong);       
            //移动手机号正则        
            string yidong = @"^(134[012345678]\d{7}|1[34578][012356789]\d{8})$";       
            Regex yReg = new Regex(yidong);

            if (dReg.IsMatch(sjh) || tReg.IsMatch(sjh) || yReg.IsMatch(sjh))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 根据当前年月计算款号前缀
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string Year_month_to_AB(int NumStartYear)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            char startYear = 'A';
            char startMonth = 'A';

            char A = (char)(startYear + year - NumStartYear);
            char B = (char)(startMonth + month - 1);

            return A.ToString() + B.ToString();
        }
        /// <summary>
        /// 计算从起始日期到现在经历的月数
        /// </summary>
        /// <param name="NumStartYear"></param>
        /// <returns></returns>
        public static string Year_month_to_num(int NumStartYear)
        {
            //计算起始日期到现在的月数
            DateTime start = new DateTime(NumStartYear, 1, 1);
            DateTime end = DateTime.Now.Date;

            int ms = (end.Year - start.Year) * 12 + end.Month - start.Month + 1;

            return ms.ToString().PadLeft(3,'0');
        }

        /// <summary>
        /// 取得指定长度的数字字符串
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static string GetRandomNum(int L)
        {
            string s = "";
            Random rd = new Random(GetRandomSeed());
            while (L > 0)
            {
                s += rd.Next(0, 10);
                L--;
            }

            return s;
        }
        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// 款号必须只能由字母和数字组成
        /// </summary>
        /// <param name="kh">款号</param>
        /// <returns></returns>
        public static bool CheckFormat_KH(string kh)
        {
            if (kh.Length > 20)
            {
                throw new MyException("款号字符不得超过20位", null);
            }

            Regex reg = new Regex(@"^[A-Za-z0-9]+$");
            if (!reg.IsMatch(kh))
            {
                throw new MyException("款号不能含有字母和数字意外的字符", null);
            }
            return true;
        }

        /// <summary>
        /// 条码只能由字母和数字组成，且最短不能小于9位，不能超过13位
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public static bool CheckFormat_TM(string tm)
        {
            if (tm.Length < 9 || tm.Length > 13)
            {
                throw new MyException("条码长度必须在9到13个字符之间", null);
            }

            Regex reg = new Regex(@"^[A-Za-z0-9]+$");
            if (!reg.IsMatch(tm))
            {
                throw new MyException("条码不能含有字母和数字意外的字符", null);
            }

            return true;
        }
        
        /// <summary>
        /// 扩展Distinct方法，可以比较多个列
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource,TKey>(this IEnumerable<TSource> source,Func<TSource,TKey> keySelector)
        {
            HashSet<TKey> hashSet = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (hashSet.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// log工具
        /// </summary>
        /// <param name="file"></param>
        /// <param name="msg"></param>
        public static void Log(string file, string msg)
        {
            try
            {
                //按日期记录
                FileInfo fi = new FileInfo(file);
                string filePath = fi.DirectoryName;
                string fileName = DateTime.Now.ToString("yyyyMMdd") + fi.Name;
                file = filePath +"\\"+ fileName;

                File.AppendAllText(file, DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "--" + msg 
                    + "\r\n------------------------------------------------------\r\n");
            }
            catch(Exception ex)
            {
                //MessageBox.Show("log消息出错，请配置好log文件\r\n" + ex.Message);
            }
        }
        public static void LogEx(string file, Exception e)
        {
            try
            {
                string errMsg = "异常--" + e.Message + "\r\n" + e.StackTrace + "\r\n";
                int i = 0;
                while (e.InnerException != null)
                {
                    if (i > 5)
                    {
                        break;
                    }

                    e = e.InnerException;
                    errMsg += "内部异常--" + e.Message + "\r\n" + e.StackTrace + "\r\n";

                    //防止无线循环
                    i++;
                }

                Log(file, errMsg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("log消息出错，请配置好log文件\r\n" + ex.Message);
            }
        }
    }

    public class MyException : Exception
    {
        public MyException(string Msg, Exception innerEx)
            : base(Msg, innerEx)
        { }
    }

    /// <summary>
    /// 异步调用费时的处理，并向用户显示处理过程中的信息
    /// </summary>
    public class ActionMessageTool
    {
        //显示msg
        public delegate void ShowMsg(string msg,bool err);
        //费时的处理函数
        public delegate void Action(ShowMsg msg);
        private event Action _action;
        //用来显示信息的对话框
        private  Dlg_Progress _dlg;
        //超时倒计时
        private System.Timers.Timer _timer;
        //处理过程是否出错
        private bool _err;
        //处理完是否自动关闭对话框
        private bool _auto;

        //鉴于一般操作不会超过60秒,进度条设为60秒满格
        private const int _TIMEOUT = 60;


        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="action">费时的处理操作</param>
        /// <param name="timeOut">超时时间，用于显示进度条</param>
        public ActionMessageTool(Action action,bool autoClose)
        {
            _action = action;

            _dlg = new Dlg_Progress();
            _dlg.ControlBox = false;
            _dlg.pgb.Maximum = _TIMEOUT;
            _dlg.StartPosition = FormStartPosition.CenterScreen;
            
            _timer = new System.Timers.Timer(1000);
            _timer.AutoReset = true;
            _timer.Elapsed += delegate 
            {
                _dlg.pgb.Value ++;
            };
            _err = false;
            _auto = autoClose;
        }

        /// <summary>
        /// 开始处理
        /// </summary>
        public void Start()
        {
            _action.BeginInvoke(ShowMessage, Finish, null);
            _timer.Start();
            _dlg.Runing = true;
            _dlg.ShowDialog();            
        }

        /// <summary>
        /// 显示消息给用户
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg,bool err)
        {
            _dlg.lbl_msg.Text = msg;
            _err = err;
        }

        /// <summary>
        /// 处理结束
        /// </summary>
        /// <param name="asyncResult"></param>
        private void Finish(IAsyncResult asyncResult)
        {
            _timer.Stop();
            _dlg.Runing = false;
            _dlg.pgb.Value = _dlg.pgb.Maximum;
            if (_auto && !_err)
            {
                _dlg.DialogResult = DialogResult.OK;
            }
            else
            {
                //不自动关闭，就要给关闭按钮让用户自己关闭
                _dlg.ControlBox = true;
            }
        }
    }

    /// <summary>
    /// 数据库工具
    /// </summary>
    public class DBTool
    {
        private string _conn;

        public DBTool(string conn)
        {
            _conn = conn;
        }

        public void CreateDatabase(string sql)
        {
            SqlConnection tmpConn = new SqlConnection(_conn);
            SqlCommand myCommand = new SqlCommand(sql, tmpConn);
            try
            {
                tmpConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tmpConn.Close();
            }

            return;
        }

        public void BackUp(string file)
        {
            SqlConnection tmpConn = new SqlConnection(_conn);

            string sqlStmt = String.Format("BACKUP DATABASE {0} TO DISK='{1}'", tmpConn.Database, file);
            SqlCommand cmd = new SqlCommand(sqlStmt, tmpConn);

            try
            {
                tmpConn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tmpConn.Close();
            }

        }

        public void Restore(string fromFile,string dbPath)
        {
            SqlConnection tmpConn = new SqlConnection(_conn);
            string sqlStmt = String.Format("RESTORE DATABASE {0} FROM DISK = '{1}' WITH MOVE '{0}.mdf' TO '{2}{0}.mdf',   MOVE '{0}.ldf' TO '{2}{0}.ldf'", tmpConn.Database,fromFile, dbPath);
            SqlCommand cmd = new SqlCommand(sqlStmt, tmpConn);

            try
            {
                tmpConn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tmpConn.Close();
            }
        }

        /// <summary>
        /// 取得设计版本
        /// </summary>
        /// <returns></returns>
        //public int GetVersion()
        //{
        //    int v = 0;
        //    using (SqlConnection conn = new SqlConnection(_conn))
        //    {
        //        string sqlStmt = String.Format("SELECT CAST(value AS int) sys.extended_properties where name = 'Version'");
        //        SqlCommand cmd = new SqlCommand(sqlStmt, conn);
        //        conn.Open();
        //        v = (int)cmd.ExecuteScalar();
        //        conn.Close();
        //    }
        //    return v;
        //}
        /// <summary>
        /// 设置版本号
        /// </summary>
        /// <param name="v"></param>
        //public void SetVersion(int v)
        //{
        //    using (SqlConnection conn = new SqlConnection(_conn))
        //    {
        //        string sqlStmt = String.Format("EXEC sp_updateextendedproperty @name = N'Version', @value = '{0}'", v);
        //        SqlCommand cmd = new SqlCommand(sqlStmt, conn);
        //        conn.Open();
        //        v = cmd.ExecuteNonQuery();
        //        conn.Close();
        //    }
        //}
    }
}
