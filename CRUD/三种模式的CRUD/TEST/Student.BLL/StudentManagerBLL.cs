using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL;

namespace Student.BLL
{
    public class StudentManagerBLL : IBaseBLL.IStudentBLL
    {
        private readonly static StudentServerDAL dal = new StudentServerDAL();

        public Model.StudentsModel GetModel(int sid)
        {
            return dal.GetModel(sid);
        }

        public List<Model.StudentsModel> GetList(int pageSize, int pageIndex)
        {
            return dal.GetList(pageSize, pageIndex);
        }

        public bool Delete(int sid)
        {
            return dal.Delete(sid) > 0;
        }

        public bool Add(Model.StudentsModel model)
        {
            return dal.Add(model) > 0;
        }

        public bool Update(Model.StudentsModel model)
        {
            return dal.Update(model) > 0;
        }

        public int GetDataAllCount()
        {
            return dal.GetDataAllCount();
        }
    }
}
