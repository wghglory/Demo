using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ajax.CRUD.Model;
using Ajax.CRUD.DAL;

namespace Ajax.CRUD.BLL
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
