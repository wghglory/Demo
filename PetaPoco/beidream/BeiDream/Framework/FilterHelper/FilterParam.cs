using System.Data;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace BeiDream.Framework.Common
{
    /// <summary>
    /// 用于存放过滤参数,比如一个是名称,一个是值,等价于sql中的Parameters
    /// </summary>
    public class FilterParam
    {
        public FilterParam(string name, object value)
        {
            this.name = name;
            this.value = value;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        /// <summary>
        /// 转化为ObjectParameter可变参数
        /// </summary>
        /// <returns></returns>
        //public ObjectParameter ToObjParam()
        //{
        //    ObjectParameter param = new ObjectParameter(this.Name,this.Value);
        //    return param;
        //}
        /// <summary>
        /// 为查询语句添加参数
        /// </summary>
        /// <param name="commandText">查询命令</param>
        /// <returns></returns>
        public static string AddParameters(string commandText, IEnumerable<FilterParam> listfilter)
        {
            foreach (FilterParam param in listfilter)
            {
                if (Tools.IsValidInput(param.Value))
                {
                    if (param.Value is int)    //       参数化替换时检测字段类型，进行相应sql语句拼写，目前只针对了int判断
                    {
                        commandText = commandText.Replace("@" + param.Name, param.Value.ToString());
                    }
                    else
                        commandText = commandText.Replace("@" + param.Name, "'" + param.Value.ToString() + "'");
                }

            }
            return commandText;
        }
        /// <summary>
        /// 模型类的参数化转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetSQL<T>(string commandText, T model)
        {
            PropertyInfo[] PropertyInfos = model.GetType().GetProperties();
            foreach (PropertyInfo property in PropertyInfos)
            {
                if (property.PropertyType.ToString() == "System.Int32" || property.PropertyType.ToString() == "System.Nullable`1[System.Int32]")    //       参数化替换时检测字段类型，进行相应sql语句拼写，目前只针对了int判断
                {
                    commandText = commandText.Replace("@" + property.Name, property.GetValue(model, null).ToString());
                }
                else
                {
                    commandText = commandText.Replace("@" + property.Name, "'" + property.GetValue(model, null).ToString() + "'");
                }
            }
            return commandText;
        }
        /// <summary>
        /// 转化为ObjectParameter可变参数
        /// </summary>
        /// <param name="listfilter"></param>
        /// <returns></returns>
        //public static ObjectParameter[] ConvertToListObjParam(IEnumerable<FilterParam> listfilter)
        //{
        //    List<ObjectParameter> list = new List<ObjectParameter>();
        //    foreach (FilterParam param in listfilter)
        //    {
        //        list.Add(param.ToObjParam());
        //    }
        //    return list.ToArray();
        //}

    }
}
