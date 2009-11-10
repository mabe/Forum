using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Conventions;

namespace Forum.UI.Web.Data.Conventions
{
	public class EntryPropertyConvention : IPropertyConvention
	{
		#region IConvention<IPropertyInspector,IPropertyInstance> Members

		public void Apply(FluentNHibernate.Conventions.Instances.IPropertyInstance instance)
		{
			if (instance.Property.Name == "Entry")
			{
				instance.CustomSqlType("text");
			}
		}

		#endregion
	}
}