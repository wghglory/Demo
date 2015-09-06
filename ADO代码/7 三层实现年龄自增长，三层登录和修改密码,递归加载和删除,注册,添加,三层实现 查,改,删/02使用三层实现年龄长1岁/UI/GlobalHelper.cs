using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08使用三层实现年龄长1岁.UI
{

    //根据当前题目的需求，这个静态类的作用是为了在表现层的窗体之间
    //传递数据用的，所以这个类应该下载表现层。换了其他不同的表现层（比如B/S）的方式，可能根本不需要使用这个静态类了，可以使用其他方法来传值。
    public static class GlobalHelper
    {
        public static int _autoId;
    }
}
