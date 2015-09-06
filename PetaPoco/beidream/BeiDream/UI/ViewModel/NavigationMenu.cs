using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BeiDream.UI
{
    public class NavigationMenu
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool leaf { get; set; }
        public string url { get; set; }
        [JsonProperty("expanded")]     //jsonnet转换为标注字段名称
        public bool Expanded { get; set; }
        public string iconCls { get; set; }
        public List<NavigationMenu> children { get; set; }
    }
}