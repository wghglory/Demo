using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ajax.CRUD.Model
{
    [Serializable()]
    public class Aspx_News
    {
        public int NewsId
        {
            get;
            set;
        }
        public string NewsTitle
        {
            get;
            set;
        }
        public string NewsContent
        {
            get;
            set;
        }
        public DateTime? NewsIssueDate
        {
            get;
            set;
        }
        public string NewsAuthor
        {
            get;
            set;
        }
        public string NewsImage
        {
            get;
            set;
        }
        public string NewsSmallImage
        {
            get;
            set;
        }
        public int NewsTypeId
        {
            get;
            set;
        }
        public Aspx_Type Aspx_TypeObject
        {
            get;
            set;
        }
    }
}
