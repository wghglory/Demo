using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax.CRUD.UI
{
    [Serializable]
    public class Person
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

    }
}