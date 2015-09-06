using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Model;

namespace Homework.DAL
{
    public partial class CustomersManager
    {
        /// <summary>
        /// 获取表中的全部数据
        /// </summary>
        /// <returns></returns>
        public List<Customers> GetAllReader()
        {
            List<Customers> list = new List<Customers>();
            using (SqlDataReader reader = Alian_SQL_Helper.SQL_Helper.ExecuteReader(
                    "select CC_AutoId, CC_CustomerName, CC_CellPhone, CC_Landline, CC_Postcode, CC_Email, CC_Address, CC_BranchId, CC_BuyDate, CC_CarNum, CC_BracketNum, CC_Brand, CC_TypeNum, CC_Suggestion, CC_Remarks from T_Customers",
                    CommandType.Text))
            {
                if (reader.HasRows)
                {

                    //CC_AutoId, CC_CustomerName, CC_CellPhone, CC_Landline, CC_Postcode, 
                    //CC_Email, CC_Address, CC_BranchId, CC_BuyDate, CC_CarNum, CC_BracketNum, 
                    //CC_Brand, CC_TypeNum, CC_Suggestion, CC_Remarks

                    #region CC_AutoId, CC_CustomerName, CC_CellPhone, CC_Landline, CC_Postcode,
                    //CC_Email, CC_Address, CC_BranchId, CC_BuyDate, CC_CarNum, CC_BracketNum, 
                    //CC_Brand, CC_TypeNum, CC_Suggestion, CC_Remarks


                    int autoIdIndex = reader.GetOrdinal("CC_AutoId");
                    int customerNameIndex = reader.GetOrdinal("CC_CustomerName");
                    int cellPhoneIndex = reader.GetOrdinal("CC_CellPhone");
                    int landlineIndex = reader.GetOrdinal("CC_Landline");
                    int postcodeIndex = reader.GetOrdinal("CC_Postcode");
                    int emailIndex = reader.GetOrdinal("CC_Email");
                    int addressIndex = reader.GetOrdinal("CC_Address");
                    int branchIdIndex = reader.GetOrdinal("CC_BranchId");
                    int buyDateIndex = reader.GetOrdinal("CC_BuyDate");
                    int carNumIndex = reader.GetOrdinal("CC_CarNum");
                    int bracketNumIndex = reader.GetOrdinal("CC_BracketNum");
                    int brandIndex = reader.GetOrdinal("CC_Brand");
                    int typeNumIndex = reader.GetOrdinal("CC_TypeNum");
                    int suggestionIndex = reader.GetOrdinal("CC_Suggestion");
                    int remarksIndex = reader.GetOrdinal("CC_Remarks");
                    #endregion


                    while (reader.Read())
                    {
                        #region ---


                        Customers model = new Customers
                                              {
                                                  CC_AutoId = reader.GetInt32(autoIdIndex),
                                                  CC_CustomerName = reader.IsDBNull(customerNameIndex)
                                                                        ? null
                                                                        : reader.GetString(customerNameIndex),
                                                  CC_CellPhone = reader.IsDBNull(cellPhoneIndex)
                                                                     ? null
                                                                     : reader.GetString(cellPhoneIndex),
                                                  CC_Landline = reader.IsDBNull(landlineIndex)
                                                                    ? null
                                                                    : reader.GetString(landlineIndex),
                                                  CC_Postcode = reader.IsDBNull(postcodeIndex)
                                                                    ? null
                                                                    : reader.GetString(postcodeIndex),
                                                  CC_Email = reader.IsDBNull(emailIndex)
                                                                 ? null
                                                                 : reader.GetString(emailIndex),
                                                  CC_Address = reader.IsDBNull(addressIndex)
                                                                   ? null
                                                                   : reader.GetString(addressIndex),
                                                  CC_BranchId = reader.IsDBNull(branchIdIndex)
                                                                    ? null
                                                                    : reader.GetString(branchIdIndex),
                                                  CC_BuyDate = reader.IsDBNull(buyDateIndex)
                                                                   ? null
                                                                   : (DateTime?)reader.GetDateTime(buyDateIndex),
                                                  CC_CarNum = reader.IsDBNull(carNumIndex)
                                                                  ? null
                                                                  : reader.GetString(carNumIndex),
                                                  CC_BracketNum = reader.IsDBNull(bracketNumIndex)
                                                                      ? null
                                                                      : reader.GetString(bracketNumIndex),
                                                  CC_Brand = reader.IsDBNull(brandIndex)
                                                                 ? null
                                                                 : reader.GetString(brandIndex),
                                                  CC_TypeNum = reader.IsDBNull(typeNumIndex)
                                                                   ? null
                                                                   : reader.GetString(typeNumIndex),
                                                  CC_Suggestion = reader.IsDBNull(suggestionIndex)
                                                                      ? null
                                                                      : reader.GetString(suggestionIndex),
                                                  CC_Remarks = reader.IsDBNull(remarksIndex)
                                                                   ? null
                                                                   : reader.GetString(remarksIndex)
                                              };
                        #endregion


                        list.Add(model);
                    }
                }
            }
            return list;
        }
    }
}
