using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.IBaseBLL
{
    public interface IStudentBLL
    {
        List<Student.Model.StudentsModel> GetList(int pageSize, int pageIndex);

        bool Delete(int sid);
        bool Add(Student.Model.StudentsModel model);
        bool Update(Student.Model.StudentsModel model);

        int GetDataAllCount();
    }
}
