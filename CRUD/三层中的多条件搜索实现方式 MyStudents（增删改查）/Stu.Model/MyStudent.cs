using System;
using System.Collections.Generic;
using System.Text;

namespace Stu.Model
{
    [Serializable()]
    public class MyStudent
    {
        public int Fid
        {
            get;
            set;
        }
        public string FName
        {
            get;
            set;
        }
        public int FAge
        {
            get;
            set;
        }
        public string FGender
        {
            get;
            set;
        }
        public int? FMath
        {
            get;
            set;
        }
        public int FEnglish
        {
            get;
            set;
        }
        public MyClass Class
        {
            get;
            set;
        }
        public DateTime FBirthday
        {
            get;
            set;
        }
    }
}
