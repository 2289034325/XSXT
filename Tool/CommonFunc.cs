using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Management;
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
            string tzm = "";
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
            tzm += mac;

            //cpu序列号
            string cpuInfo = "";
            mc = new ManagementClass("Win32_Processor");
            moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
            }
            tzm += cpuInfo;


            return tzm;
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
                return false;
            }

            Regex reg = new Regex(@"^[A-Za-z0-9]+$");
            return reg.IsMatch(kh);
        }

        /// <summary>
        /// 条码只能由字母和数字组成
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        public static bool CheckFormat_TM(string tm)
        {
            if (tm.Length != 13)
            {
                return false;
            }

            Regex reg = new Regex(@"^[A-Za-z0-9]+$");
            return reg.IsMatch(tm);
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
                File.AppendAllText(file, DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + msg + "\r\n");
            }
            finally
            {
 
            }
        }
    }

    public class MyException : Exception
    {
        public MyException(string Msg):base(Msg)
        {}
    }
}
