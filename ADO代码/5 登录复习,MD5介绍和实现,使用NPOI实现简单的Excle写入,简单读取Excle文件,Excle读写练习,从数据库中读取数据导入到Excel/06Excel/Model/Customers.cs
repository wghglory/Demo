using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Model
{
    public class Customers
    {
        public Customers()
        {

        }
        #region Model
        private int _cc_autoid;
        private string _cc_customername;
        private string _cc_cellphone;
        private string _cc_landline;
        private string _cc_postcode;
        private string _cc_email;
        private string _cc_address;
        private string _cc_branchid;
        private DateTime? _cc_buydate;
        private string _cc_carnum;
        private string _cc_bracketnum;
        private string _cc_brand;
        private string _cc_typenum;
        private string _cc_suggestion;
        private string _cc_remarks;
        /// <summary>
        /// 
        /// </summary>
        public int CC_AutoId
        {
            set { _cc_autoid = value; }
            get { return _cc_autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_CustomerName
        {
            set { _cc_customername = value; }
            get { return _cc_customername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_CellPhone
        {
            set { _cc_cellphone = value; }
            get { return _cc_cellphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_Landline
        {
            set { _cc_landline = value; }
            get { return _cc_landline; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_Postcode
        {
            set { _cc_postcode = value; }
            get { return _cc_postcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_Email
        {
            set { _cc_email = value; }
            get { return _cc_email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_Address
        {
            set { _cc_address = value; }
            get { return _cc_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_BranchId
        {
            set { _cc_branchid = value; }
            get { return _cc_branchid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CC_BuyDate
        {
            set { _cc_buydate = value; }
            get { return _cc_buydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_CarNum
        {
            set { _cc_carnum = value; }
            get { return _cc_carnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_BracketNum
        {
            set { _cc_bracketnum = value; }
            get { return _cc_bracketnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_Brand
        {
            set { _cc_brand = value; }
            get { return _cc_brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_TypeNum
        {
            set { _cc_typenum = value; }
            get { return _cc_typenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_Suggestion
        {
            set { _cc_suggestion = value; }
            get { return _cc_suggestion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC_Remarks
        {
            set { _cc_remarks = value; }
            get { return _cc_remarks; }
        }
        #endregion Model
    }
}
