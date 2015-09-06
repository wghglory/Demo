using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace _01三层.Tools
{
    public static class CommonHelper
    {
        //计算字符串的Md5
        public static string GetMd5StringFromString(string inputString)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] buffers = Encoding.UTF8.GetBytes(inputString);
                byte[] md5Buffers = md5.ComputeHash(buffers);
                StringBuilder sbMd5 = new StringBuilder();
                for (int i = 0; i < md5Buffers.Length; i++)
                {
                    sbMd5.Append(md5Buffers[i].ToString("x2"));
                }
                md5.Clear();
                return sbMd5.ToString();
            }
        }

    }
}
