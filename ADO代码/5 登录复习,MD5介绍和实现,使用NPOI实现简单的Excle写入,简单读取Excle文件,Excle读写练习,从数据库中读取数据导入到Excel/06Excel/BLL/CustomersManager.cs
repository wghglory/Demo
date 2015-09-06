using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Model;

namespace Homework.BLL
{
    public partial class CustomersManager
    {
        private static readonly DAL.CustomersManager dal = new DAL.CustomersManager();

        public List<Customers> GetAllReader()
        {
            return dal.GetAllReader();
        }
    }
}
