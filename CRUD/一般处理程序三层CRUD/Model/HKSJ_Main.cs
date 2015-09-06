//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralHandler.Model
{	
	[Serializable()]
	public class HKSJ_Main
	{	
			public int ID
			{
				get;
				set;
			}
			public string Title
			{
				get;
				set;
			}
			public string Content
			{
				get;
				set;
			}
			public string Type
			{
				get;
				set;
			}
			public DateTime Date
			{
				get;
				set;
			}
			public string People
			{
				get;
				set;
			}
			public string PicUrl
			{
				get;
				set;
			}
	}
}