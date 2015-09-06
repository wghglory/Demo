using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Core.Config;
using System.Xml.Serialization;

namespace BeiDream.UI.Config
{
    [Serializable]
    public class NavigationMenuConfig : ConfigFileBase
    {
        public NavigationMenuConfig()
        {
        }

        public NavigationMenu[] NavigationMenus { get; set; }
    }

    [Serializable]
    public class NavigationMenu
    {
        public List<NavigationMenuArray> NavigationMenuArrays { get; set; }
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlAttribute("text")]
        public string text { get; set; }

        [XmlAttribute("url")]
        public string url { get; set; }

        [XmlAttribute("leaf")]
        public bool leaf { get; set; }
    }

    [Serializable]
    public class NavigationMenuArray
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlAttribute("text")]
        public string text { get; set; }

        [XmlAttribute("url")]
        public string url { get; set; }

        [XmlAttribute("leaf")]
        public bool leaf { get; set; }
    }
}