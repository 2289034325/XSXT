using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tool
{
    public class CommonFunc
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
        /// 初始化下拉框
        /// </summary>
        /// <param name="Cmb"></param>
        /// <param name="Items"></param>
        public static void InitCombbox(ComboBox Cmb,Type type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            Array vs = Enum.GetValues(type);
            foreach (Enum v in vs)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = Enum.GetName(type, v);
                dr["Value"] = Convert.ToInt16(v);
                dt.Rows.Add(dr);
            }

            Cmb.DisplayMember = "Text";
            Cmb.ValueMember = "Value";
            Cmb.DataSource = dt;
        }
        public static void InitCombbox(DropDownList Cmb, Type type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            Array vs = Enum.GetValues(type);
            foreach (Enum v in vs)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = Enum.GetName(type, v);
                dr["Value"] = Convert.ToInt16(v);
                dt.Rows.Add(dr);
            }

            Cmb.DataTextField = "Text";
            Cmb.DataValueField = "Value";
            Cmb.DataSource = dt;
            Cmb.DataBind();
        }
        public static void InitCombbox(DropDownList Cmb, object[] Items,string TextField,string ValueField)
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
        /// 验证动态密码
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public static bool ValidateDTMM(string mm)
        {
            string bm = getDTMM();
            if (mm == bm)
            {
                //重新生成动态密码
                string nm = makeNewDTMM();
                setNewDTMM(nm);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 将新动态密码保存入配置文件
        /// </summary>
        /// <param name="nm"></param>
        private static void setNewDTMM(string nm)
        {
            XElement xe = XElement.Load(@"Settings.xml");
            XElement dmnode = xe.Elements().Single(r => r.Name == "DTMM");
            dmnode.Value = nm;

            xe.Save(@"Settings.xml");
        }

        /// <summary>
        /// 生成新的动态密码
        /// </summary>
        /// <returns></returns>
        private static string makeNewDTMM()
        {
            Random r = new Random();
            string nm = "";
            string[] sources = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i < 5; i++)
            {
                nm += sources[r.Next(0, sources.Length - 1)];
            }

            return nm;
        }

        /// <summary>
        /// 从配置文件取得动态密码
        /// </summary>
        /// <returns></returns>
        private static string getDTMM()
        {
            XElement xe = XElement.Load(@"Settings.xml");
            XElement dmnode = xe.Elements().Single(r => r.Name == "DTMM");

            return dmnode.Value;
        }
    }

    public class MyException : Exception
    {
        public MyException(string Msg):base(Msg)
        {}
    }
}
