using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ajax.CRUD.Model
{
    [Serializable]
    public class Aspx_Students
    {
        public int StuId
        {
            get;
            set;
        }
        public string StuName
        {
            get;
            set;
        }
        public int? StuAge
        {
            get;
            set;
        }
        public string StuGender
        {
            get;
            set;
        }
        public string StuEmail
        {
            get;
            set;
        }
        public DateTime StuBirthday
        {
            get;
            set;
        }
    }
}
