using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOnly
{
    public class Employee
    {
        public Employee()
        {
            EmpOrder = new HashSet<EmpOrder>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        public virtual ICollection<EmpOrder> EmpOrder { get; set; }

    }
}
