using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02省市联动
{
    public class ProvinceItem
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int AreaPid { get; set; }
        public override string ToString()
        {
            return this.AreaName;
        }
    }
}
