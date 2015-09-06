using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05资料管理器
{
    public class ContentInfo
    {
        public int DId { get; set; }
        public int DTId { get; set; }
        public string DName { get; set; }
        public string DContent { get; set; }

        public override string ToString()
        {
            return this.DName;
        }
    }
}
