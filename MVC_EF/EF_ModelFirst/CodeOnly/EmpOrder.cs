using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOnly
{
    public class EmpOrder
    {

        [Key]
        public int Id { get; set; }

        [StringLength(32)]
        public string OrderContent { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
