using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts.Model
{
    public class T_Scripts
    {
        //ScriptId, ScriptTitle, ScriptMsg, ScriptParentId

        public int ScriptId { get; set; }
        public string ScriptTitle { get; set; }
        public string ScriptMsg { get; set; }
        public int ScriptParentId { get; set; }
    }
}
