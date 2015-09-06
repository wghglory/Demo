//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace NvelocityCommentPractice.Model
{	
	[Serializable()]
	public class T_Msg
	{	
			public int Id
			{
				get;
				set;
			}
			public string Title
			{
				get;
				set;
			}
			public string Message
			{
				get;
				set;
			}
			public string NickName
			{
				get;
				set;
			}
			public bool IsAnonymous
			{
				get;
				set;
			}
			public string IPAddress
			{
				get;
				set;
			}
			public DateTime PostDate
			{
				get;
				set;
			}
	}
}