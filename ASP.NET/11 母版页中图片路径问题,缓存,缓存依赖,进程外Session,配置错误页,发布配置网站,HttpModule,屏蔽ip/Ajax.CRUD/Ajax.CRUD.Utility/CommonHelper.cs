using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Ajax.CRUD.Utility
{
    public static class CommonHelper
    {
        public static string GetMD5FromString(string input)
        {
            //1.创建一个md5对象
            MD5 md5Obj = MD5.Create();
            //1.1把字符串转换为byte[]
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(input);

            //2.通过md5对象计算给定值的md5
            byte[] md5Buffer = md5Obj.ComputeHash(buffer);
            // 把byte[]数组转换为字符串
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Buffer.Length; i++)
            {
                sb.Append(md5Buffer[i].ToString("x2"));
            }
            //3.释放资源
            md5Obj.Clear();
            return sb.ToString();
        }

        public static string GetSHA512FromString(string input)
        {
            //1.创建一个md5对象
            SHA512 md5Obj = SHA512.Create();
            //1.1把字符串转换为byte[]
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(input);

            //2.通过md5对象计算给定值的md5
            byte[] md5Buffer = md5Obj.ComputeHash(buffer);
            // 把byte[]数组转换为字符串
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Buffer.Length; i++)
            {
                sb.Append(md5Buffer[i].ToString("x2"));
            }
            //3.释放资源
            md5Obj.Clear();
            return sb.ToString();
        }
    }

}
