using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;

namespace _04更新表中的拼音列
{
    public static class CommonHelper
    {
        public static string ConvertChineseToPinyin(string str)
        {
            StringBuilder sbpy = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                
                if (ChineseChar.IsValidChar(str[i]))
                {
                    ChineseChar cnChar = new ChineseChar(str[i]);
                    if (cnChar.PinyinCount > 0)
                    {
                        sbpy.Append(cnChar.Pinyins[0].Remove(cnChar.Pinyins[0].Length - 1));
                    }
                }

            }

            return sbpy.ToString();
        }
    }
}
