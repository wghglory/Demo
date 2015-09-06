using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model
{
    [Serializable]
    public partial class StudentsModel
    {
        public StudentsModel()
        {
        }

        #region Model

        private int _sid;
        private string _sname;
        private int _sage;
        private string _semail;
        private DateTime _sbirthday;
        private string _sgender;

        /// <summary>
        /// 
        /// </summary>
        public int SId
        {
            set { _sid = value; }
            get { return _sid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SName
        {
            set { _sname = value; }
            get { return _sname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SAge
        {
            set { _sage = value; }
            get { return _sage; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SEmail
        {
            set { _semail = value; }
            get { return _semail; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime SBirthday
        {
            set { _sbirthday = value; }
            get { return _sbirthday; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SGender
        {
            set { _sgender = value; }
            get { return _sgender; }
        }

        #endregion Model
    }
}
