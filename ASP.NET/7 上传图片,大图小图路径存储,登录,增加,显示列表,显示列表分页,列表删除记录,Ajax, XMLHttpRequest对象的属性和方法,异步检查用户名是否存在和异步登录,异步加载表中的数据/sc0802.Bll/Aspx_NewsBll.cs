using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using sc0802.Dal;

namespace sc0802.Bll
{
    public class Aspx_NewsBll
    {
        private Aspx_NewsDal dal = new Aspx_NewsDal();
        public int Add(Aspx_News model)
        {
            return dal.Add(model);
        }

        public List<Aspx_News> GetAllNews()
        {
            return dal.GetAllNews();
        }

        public List<Aspx_News> GetNewsByPage(int pageSize, int pageIndex, out int recordCount, out int pageCount)
        {
            return dal.GetNewsByPage(pageSize, pageIndex, out recordCount, out pageCount);
        }

        public int DeleteByNewsId(int nid)
        {
            return dal.DeleteByNewsId(nid);
        }

        public Aspx_News GetNewsModelByNewsId(int id)
        {
            return dal.GetNewsModelByNewsId(id);
        }
    }
}
