using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DevelopmentWithADot.AspNetCustomDataSourceControl
{
	sealed class CustomDataSourceView : DataSourceView
	{
		private readonly CustomDataSourceControl dataSourceControl = null;

		public CustomDataSourceView(CustomDataSourceControl dataSourceControl, String viewName) : base(dataSourceControl, viewName)
		{
			this.dataSourceControl = dataSourceControl;
		}

		public override Boolean CanPage
		{
			get
			{
				return (true);
			}
		}

		public override Boolean CanRetrieveTotalRowCount
		{
			get
			{
				return (true);
			}
		}

		public override Boolean CanSort
		{
			get
			{
				return (true);
			}
		}

		protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
		{
			if (this.dataSourceControl.Enabled == true)
			{
				IOrderedDictionary parameters = this.dataSourceControl.DataParameters.GetValues(HttpContext.Current, this.dataSourceControl);
				DataEventArgs args = new DataEventArgs(this.dataSourceControl.PageSize, arguments.StartRowIndex, arguments.SortExpression, parameters);

				this.dataSourceControl.GetData(args);

				arguments.TotalRowCount = args.TotalRowCount;
				arguments.MaximumRows = this.dataSourceControl.PageSize;
				arguments.AddSupportedCapabilities(DataSourceCapabilities.Page | DataSourceCapabilities.Sort | DataSourceCapabilities.RetrieveTotalRowCount);
				arguments.RetrieveTotalRowCount = true;

				if (!(args.Data is ICollection))
				{
					return (args.Data.OfType<Object>().ToList());
				}
				else
				{
					return (args.Data);
				}
			}
			else
			{
				arguments.TotalRowCount = 0;
				return (new ArrayList());
			}
		}
	}
}