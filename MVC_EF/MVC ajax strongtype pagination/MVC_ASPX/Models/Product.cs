using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ASPX.Models
{
    //单独的类可以这么用，但是EF的model，不能这么打上标签，不然重新更新模型所有的标签就没了。
    //用元数据共享的办法解决。见UserExt.cs
    public class Product
    {
        [StringLength(5, ErrorMessage = "*不能超过5个字符")]
        [Required(ErrorMessage = "*必填")]
        public string PName { get; set; }


        //特性怎么用：特性只能通过反射读取。

        public void Sell(Product product)
        {
            //如果打了标签，那么就不卖了。没有就卖了。
        }

        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "*必须是邮箱")]
        public string Remark { get; set; }

        [Range(10, 19, ErrorMessage = "*必须是10-19之间的一个数字")]
        public int Id { get; set; }
    }
}