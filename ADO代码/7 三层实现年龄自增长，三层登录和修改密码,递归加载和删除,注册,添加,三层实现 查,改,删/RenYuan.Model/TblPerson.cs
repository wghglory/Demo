using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RenYuan.Model
{
    public class TblPerson
    {
        public int AutoId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int? Height { get; set; }
        public bool? Gender { get; set; }
    }
}
