using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ajax.CRUD.DAL;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.BLL
{
    public class Aspx_StudentsBll
    {
        private Aspx_StudentsDal dal = new Aspx_StudentsDal();
        public List<Aspx_Students> GetAllStudents()
        {
            return dal.GetAllStudents();
        }

        public List<Aspx_Students> GetStudentsByPage(int pagesize, int pageindex, out int recordcount, out int pagecount)
        {
            return dal.GetStudentsByPage(pagesize, pageindex, out recordcount, out pagecount);
        }
    }
}
