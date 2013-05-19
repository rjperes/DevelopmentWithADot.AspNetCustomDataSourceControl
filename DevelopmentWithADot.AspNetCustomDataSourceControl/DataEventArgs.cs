using System;
using System.Collections;
using System.Collections.Specialized;

namespace DevelopmentWithADot.AspNetCustomDataSourceControl
{
	[Serializable]
	public class DataEventArgs : EventArgs
	{
		public DataEventArgs(Int32 pageSize, Int32 startRowIndex, String sortExpression, IOrderedDictionary parameters)
		{
			this.PageSize = pageSize;
			this.StartRowIndex = startRowIndex;
			this.SortExpression = sortExpression;
			this.Parameters = parameters;
		}

		public IOrderedDictionary Parameters
		{
			get;
			private set;
		}

		public String SortExpression
		{
			get;
			private set;
		}

		public Int32 StartRowIndex
		{
			get;
			private set;
		}

		public Int32 PageSize
		{
			get;
			private set;
		}

		public Int32 TotalRowCount
		{
			get;
			set;
		}

		public IEnumerable Data
		{
			get;
			set;
		}
	}
}