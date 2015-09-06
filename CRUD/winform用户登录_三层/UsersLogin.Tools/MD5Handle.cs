using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsersLogin.Tools
{
    public static class MD5Handle
    {
        /// <summary>
        /// 把普通字符串转换成MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringConventMD5(string str)
        {
            //创建一个MD5对象
            MD5 md5 = MD5.Create();
            //把字符串转换成Byte数组
            byte[] btyArr = Encoding.Default.GetBytes(str);
            //把字符串数据转换成md5 byte数组
            byte[] md5Arr = md5.ComputeHash(btyArr);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Arr.Length; i++)
            {
                //十六进制数据
                sb.Append(md5Arr[i].ToString("x2"));
            }

            return sb.ToString();

        }
    }
}
