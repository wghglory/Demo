using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scripts.Model;
using Scripts.DAL;

namespace Scripts.BLL
{
    public class T_ScriptsBll
    {
        T_ScriptsDal dal = new T_ScriptsDal();
        public List<T_Scripts> GetScriptsByParentId(int pid)
        {
            return dal.GetScriptsByParentId(pid);
        }

        public string GetScriptMessageByScriptId(int sid)
        {
            object objMsg = dal.GetScriptMessageByScriptId(sid);
            if (objMsg != null)
            {
                return objMsg.ToString();
            }
            return null;
        }

        public int AddScripts(T_Scripts model)
        {
            return dal.AddScripts(model);
        }

        public int DeleteByScriptId(int sid)
        {
            return dal.DeleteByScriptId(sid);
        }

        //递归删除
        public void DeleteScriptsDiGui(int sid)
        {
            //1.先根据当前Id查找所有子元素
            List<T_Scripts> list = GetScriptsByParentId(sid);
            foreach (var item in list)
            {
                DeleteScriptsDiGui(item.ScriptId);
            }

            //2.删除当前sid的记录
            DeleteByScriptId(sid);
        }

        //更新
        public int UpdateScript(T_Scripts model)
        {
            return dal.UpdateScript(model);
        }

    }
}
