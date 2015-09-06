using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _02三层中的多条件搜索实现方式.DAL;

namespace _02三层中的多条件搜索实现方式.BLL
{
    class BookBLL
    {

        public List<string> Search(List<Condition> list)
        {
            BookDal dal = new BookDal();
            return dal.Search(list);
        }
    }
}
