using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01对TblStudent表实现增删查改
{
    public class ClassModel
    {

        private string _classDesc;

        public string ClassDesc
        {
            get { return _classDesc; }
            set { _classDesc = value; }
        }


        public int ClassId
        {
            get;
            set;
        }
        public string ClassName
        {
            get;
            set;
        }
        public override string ToString()
        {
            return this.ClassName;
        }
    }
}
