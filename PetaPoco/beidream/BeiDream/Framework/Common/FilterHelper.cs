using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeiDream.Framework.Common
{
  public class FilterHelper
    {
      /// <summary>
      /// 解析where并返回翻译对象(请确保UI层查询条件与数据库的模型一致,否则请自行进行对where的条件进行参数转化解析)
      /// </summary>
      /// <param name="where">查询条件where(与数据库模型一致的查询对象的where)</param>
      /// <returns></returns>
      public static string GetFilterTanslate(FilterGroup where)
      {
          string commandText = "";
          if (!Tools.IsNullOrEmpty(where))
          {
              FilterTranslator translate = new FilterTranslator();
              translate.Group = where;
              translate.Translate();
              commandText = FilterParam.AddParameters(translate.CommandText, translate.Parms);
          }
              return commandText;
      }
      public static string GetFilterTanslate(List<FilterParam> list)
      {
          string commandText = "";
          if (list != null)
          {
              FilterTranslator translate = new FilterTranslator();
              translate.UpdateParms = list;
              translate.TranslateUpdate();
              commandText = FilterParam.AddParameters(translate.CommandText, translate.Parms);
          }
          return commandText;
      }
    }
}
