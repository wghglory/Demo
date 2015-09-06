using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.IBaseDAL
{
    public interface IStudentDAL
    {

        int Delete(int Sid);
        int Add(Student.Model.StudentsModel model);
        int Update(Student.Model.StudentsModel model);
        List<Student.Model.StudentsModel> GetList(int pageSize, int pageIndex);
        int GetDataAllCount();
    }
}
