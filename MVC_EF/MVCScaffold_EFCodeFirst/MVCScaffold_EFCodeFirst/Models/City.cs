using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCScaffold_EFCodeFirst.Models
{
    public class City
    {

        [Key]
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
    }
}