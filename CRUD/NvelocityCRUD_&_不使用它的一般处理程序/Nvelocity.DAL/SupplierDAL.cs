//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Nvelocity.Model;

namespace Nvelocity.DAL
{
	public partial class SupplierDAL
	{
        public Supplier Add(Supplier supplier)
		{
				string sql ="INSERT INTO Suppliers (CompanyName, ContactName, Address, City, PostalCode, Country, Phone)  output inserted.SupplierID VALUES (@CompanyName, @ContactName, @Address, @City, @PostalCode, @Country, @Phone)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@CompanyName", ToDBValue(supplier.CompanyName)),
						new SqlParameter("@ContactName", ToDBValue(supplier.ContactName)),
						new SqlParameter("@Address", ToDBValue(supplier.Address)),
						new SqlParameter("@City", ToDBValue(supplier.City)),
						new SqlParameter("@PostalCode", ToDBValue(supplier.PostalCode)),
						new SqlParameter("@Country", ToDBValue(supplier.Country)),
						new SqlParameter("@Phone", ToDBValue(supplier.Phone)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetBySupplierID(newId);
		}

        public int DeleteBySupplierID(int supplierID)
		{
            string sql = "DELETE Suppliers WHERE SupplierID = @SupplierID";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@SupplierID", supplierID)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
						
        public int Update(Supplier supplier)
        {
            string sql =
                "UPDATE Suppliers " +
                "SET " +
			" CompanyName = @CompanyName" 
                +", ContactName = @ContactName" 
                +", Address = @Address" 
                +", City = @City" 
                +", PostalCode = @PostalCode" 
                +", Country = @Country" 
                +", Phone = @Phone" 
               
            +" WHERE SupplierID = @SupplierID";

			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@SupplierID", supplier.SupplierID)
					,new SqlParameter("@CompanyName", ToDBValue(supplier.CompanyName))
					,new SqlParameter("@ContactName", ToDBValue(supplier.ContactName))
					,new SqlParameter("@Address", ToDBValue(supplier.Address))
					,new SqlParameter("@City", ToDBValue(supplier.City))
					,new SqlParameter("@PostalCode", ToDBValue(supplier.PostalCode))
					,new SqlParameter("@Country", ToDBValue(supplier.Country))
					,new SqlParameter("@Phone", ToDBValue(supplier.Phone))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public Supplier GetBySupplierID(int supplierID)
        {
            string sql = "SELECT * FROM Suppliers WHERE SupplierID = @SupplierID";
            using(SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@SupplierID", supplierID)))
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
		
		public Supplier ToModel(SqlDataReader reader)
		{
			Supplier supplier = new Supplier();

			supplier.SupplierID = (int)ToModelValue(reader,"SupplierID");
			supplier.CompanyName = (string)ToModelValue(reader,"CompanyName");
			supplier.ContactName = (string)ToModelValue(reader,"ContactName");
			supplier.Address = (string)ToModelValue(reader,"Address");
			supplier.City = (string)ToModelValue(reader,"City");
			supplier.PostalCode = (string)ToModelValue(reader,"PostalCode");
			supplier.Country = (string)ToModelValue(reader,"Country");
			supplier.Phone = (string)ToModelValue(reader,"Phone");
			return supplier;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM Suppliers";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<Supplier> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<Supplier>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by SupplierID) rownum FROM Suppliers) t where rownum>=@minrownum and rownum<=@maxrownum";
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
		
		public IEnumerable<Supplier> GetAll()
		{
			var list = new List<Supplier>();
			string sql = "SELECT * FROM Suppliers";
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