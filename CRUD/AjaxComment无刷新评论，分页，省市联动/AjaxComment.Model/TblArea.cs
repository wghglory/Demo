//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace AjaxComment.Model
{	
	[Serializable()]
	public class TblArea
	{	
			public int AreaId
			{
				get;
				set;
			}
			public string AreaName
			{
				get;
				set;
			}
			public int? AreaPId
			{
				get;
				set;
			}
	}
}