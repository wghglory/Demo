//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Order = new HashSet<Order>();
            this.R_Department_User = new HashSet<R_Department_User>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Age { get; set; }
    
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<R_Department_User> R_Department_User { get; set; }
    }
}
