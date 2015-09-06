//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EasyUI.Model;

namespace EasyUI.DAL
{
	public partial class MyOrderDAL
	{
        public MyOrder Add(MyOrder myOrder)
		{
				string sql ="INSERT INTO MyOrders (ProductName, ProductCode, SellAmount, Purchaser, salesperson, SellDate, SellPrice)  output inserted.id VALUES (@ProductName, @ProductCode, @SellAmount, @Purchaser, @salesperson, @SellDate, @SellPrice)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ProductName", ToDBValue(myOrder.ProductName)),
						new SqlParameter("@ProductCode", ToDBValue(myOrder.ProductCode)),
						new SqlParameter("@SellAmount", ToDBValue(myOrder.SellAmount)),
						new SqlParameter("@Purchaser", ToDBValue(myOrder.Purchaser)),
						new SqlParameter("@salesperson", ToDBValue(myOrder.Salesperson)),
						new SqlParameter("@SellDate", ToDBValue(myOrder.SellDate)),
						new SqlParameter("@SellPrice", ToDBValue(myOrder.SellPrice)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE MyOrders WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
						
        public int Update(MyOrder myOrder)
        {
            string sql =
                "UPDATE MyOrders " +
                "SET " +
			" ProductName = @ProductName" 
                +", ProductCode = @ProductCode" 
                +", SellAmount = @SellAmount" 
                +", Purchaser = @Purchaser" 
                +", Salesperson = @Salesperson" 
                +", SellDate = @SellDate" 
                +", SellPrice = @SellPrice" 
               
            +" WHERE id = @id";

			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", myOrder.Id)
					,new SqlParameter("@ProductName", ToDBValue(myOrder.ProductName))
					,new SqlParameter("@ProductCode", ToDBValue(myOrder.ProductCode))
					,new SqlParameter("@SellAmount", ToDBValue(myOrder.SellAmount))
					,new SqlParameter("@Purchaser", ToDBValue(myOrder.Purchaser))
					,new SqlParameter("@Salesperson", ToDBValue(myOrder.Salesperson))
					,new SqlParameter("@SellDate", ToDBValue(myOrder.SellDate))
					,new SqlParameter("@SellPrice", ToDBValue(myOrder.SellPrice))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public MyOrder GetById(int id)
        {
            string sql = "SELECT * FROM MyOrders WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@Id", id)))
			{
				if (reader.Read())
				{
					return ToModel(reader);
				}
				else
				{
					return null;
				}
       		}
        }
		
		public MyOrder ToModel(SqlDataReader reader)
		{
			MyOrder myOrder = new MyOrder();

			myOrder.Id = (int)ToModelValue(reader,"id");
			myOrder.ProductName = (string)ToModelValue(reader,"ProductName");
			myOrder.ProductCode = (string)ToModelValue(reader,"ProductCode");
			myOrder.SellAmount = (int?)ToModelValue(reader,"SellAmount");
			myOrder.Purchaser = (string)ToModelValue(reader,"Purchaser");
			myOrder.Salesperson = (string)ToModelValue(reader,"salesperson");
			myOrder.SellDate = (DateTime?)ToModelValue(reader,"SellDate");
			myOrder.SellPrice = (decimal?)ToModelValue(reader,"SellPrice");
			return myOrder;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM MyOrders";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<MyOrder> GetPagedDataByRowNum(int minrownum,int maxrownum)
		{
			var list = new List<MyOrder>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM MyOrders) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
        
        public IEnumerable<MyOrder> GetPagedData(int pageSize,int pageIndex)
		{
			var list = new List<MyOrder>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM MyOrders) t where rownum between ((@pageIndex-1)*@pageSize)+1 and (@pageIndex*@pageSize)";
			using(SqlDataReader reader = SqlHelper.ExecuteReader(sql,
				new SqlParameter("@pageSize",pageSize),
				new SqlParameter("@pageIndex",pageIndex)))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public IEnumerable<MyOrder> GetAll()
		{
			var list = new List<MyOrder>();
			string sql = "SELECT * FROM MyOrders";
			using(SqlDataReader reader = SqlHelper.ExecuteReader(sql))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		public object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
			{
				return null;
			}
			else
			{
				return reader[columnName];
			}
		}

       


	}
}