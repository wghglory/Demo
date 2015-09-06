using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.UI.Ajax
{
    [Serializable]
    public class Datahelper
    {

        public string StrPage { set; get; }
        public List<Student.Model.StudentsModel> listStudentModel { set; get; }
    }
}