//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace EasyUI.Model
{	
	[Serializable()]
	public class MyOrder
	{	
			public int Id
			{
				get;
				set;
			}
			public string ProductName
			{
				get;
				set;
			}
			public string ProductCode
			{
				get;
				set;
			}
			public int? SellAmount
			{
				get;
				set;
			}
			public string Purchaser
			{
				get;
				set;
			}
			public string Salesperson
			{
				get;
				set;
			}
			public DateTime? SellDate
			{
				get;
				set;
			}
			public decimal? SellPrice
			{
				get;
				set;
			}
	}
}