using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
    }
}
