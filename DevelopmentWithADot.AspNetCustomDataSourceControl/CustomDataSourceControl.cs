using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevelopmentWithADot.AspNetCustomDataSourceControl
{
	[NonVisualControl]
	public class CustomDataSourceControl : DataSourceControl
	{
		public CustomDataSourceControl()
		{
			this.DataParameters = new ParameterCollection();
			this.Enabled = true;
		}

		protected override DataSourceView GetView(String viewName)
		{
			return (new CustomDataSourceView(this, viewName));
		}

		internal void GetData(DataEventArgs args)
		{
			this.OnData(args);
		}

		protected virtual void OnData(DataEventArgs args)
		{
			EventHandler<DataEventArgs> data = this.Data;

			if (data != null)
			{
				data(this, args);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public ParameterCollection DataParameters
		{
			get;
			private set;
		}

		public event EventHandler<DataEventArgs> Data;

		public Boolean Enabled
		{
			get;
			set;
		}

		public Int32 PageSize
		{
			get;
			set;
		}
	}
}