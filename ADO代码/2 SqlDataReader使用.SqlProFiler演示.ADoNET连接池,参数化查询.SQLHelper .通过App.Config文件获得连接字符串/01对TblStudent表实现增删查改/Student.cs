using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01对TblStudent表实现增删查改
{
    public class Student
    {
        //tSId, tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId

        public int TsId { get; set; }

        public string TsName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string TsCardId { get; set; }
        public int ClassId { get; set; }
    }
}
