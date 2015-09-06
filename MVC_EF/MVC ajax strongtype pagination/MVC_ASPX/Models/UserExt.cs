using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ASPX.Models
{
    [MetadataType(typeof(UserValidate))]//当前的User类共享UserValidate的元数据。
    public partial class User
    {
    }

    //元数据（Metadata）：就是程序集的说明书。
    //程序集包含什么：IL，Metadata，resource，程序集清单

    public class UserValidate  //元数据里面描述：Age属性上面有特性 [Range(10,18,ErrorMessage = "*年方10-18才行")]
    {
        [Range(0, 100, ErrorMessage = "*年方0-100才行")]
        [Required(ErrorMessage = "*必填")]
        public int Age { get; set; }

        [Required(ErrorMessage = "*必填")]
        public string Name { get; set; }

        [StringLength(30, ErrorMessage = "*最多30字")]
        [Required(ErrorMessage = "*必填")]
        public string Address { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "*必须是数字")]
        public string Phone { get; set; }

        //[RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "*必须是邮箱")]
    }
}