using System.ComponentModel.DataAnnotations;

namespace MVCScaffold_EFCodeFirst.Models
{
    public class Employee
    {
       
       [Key]
       public int EmployeeId { get; set; }
   
       [Required]
       public string EmployeeName { get; set; }

       [Required]
       public int CityId { get; set; }

 
       public virtual City City { get; set; } 
    }
}