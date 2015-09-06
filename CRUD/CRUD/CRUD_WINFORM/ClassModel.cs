using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_WINFORM
{
  
    public class ClassModel
    {
        private int _classId;
        private string _className;

        public int ClassId
        {
            get { return ClassId = _classId; }
            set { _classId = value; }
        }

        public string ClassName
        {
            get { return ClassName = _className; }
            set { _className = value; }
        }

        //method 1: add model to combobox, override ToString();
        public override string ToString()
        {
            return ClassName.ToString();
        }
    }
}
