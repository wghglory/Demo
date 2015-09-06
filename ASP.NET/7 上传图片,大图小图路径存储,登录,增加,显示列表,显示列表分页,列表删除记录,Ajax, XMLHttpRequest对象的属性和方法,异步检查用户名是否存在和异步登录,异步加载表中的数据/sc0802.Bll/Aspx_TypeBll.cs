using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc0802.Dal;
using Stu.Model;

namespace sc0802.Bll
{
    public class Aspx_TypeBll
    {
        private Aspx_TypeDal dal = new Aspx_TypeDal();
        public List<Aspx_Type> GetAllTypes()
        {
            return dal.GetAllTypes();
        }
    }
}
