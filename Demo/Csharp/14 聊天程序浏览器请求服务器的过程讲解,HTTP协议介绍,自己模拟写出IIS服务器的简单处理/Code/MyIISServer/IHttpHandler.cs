using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyIISServer
{
    //在这个接口中有一个方法，就是用来处理用户请求的
    public interface IHttpHandler
    {
        void ProcessRequest(HttpContext context);
    }
}
