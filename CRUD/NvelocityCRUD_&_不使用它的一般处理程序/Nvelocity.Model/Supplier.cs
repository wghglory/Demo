//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Nvelocity.Model
{	
	[Serializable()]
	public class Supplier
	{	
			public int SupplierID
			{
				get;
				set;
			}
			public string CompanyName
			{
				get;
				set;
			}
			public string ContactName
			{
				get;
				set;
			}
			public string Address
			{
				get;
				set;
			}
			public string City
			{
				get;
				set;
			}
			public string PostalCode
			{
				get;
				set;
			}
			public string Country
			{
				get;
				set;
			}
			public string Phone
			{
				get;
				set;
			}
	}
}