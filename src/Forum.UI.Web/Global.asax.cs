using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using NHibernate.Context;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Configuration;
using FluentNHibernate.Automapping;
using System.Reflection;
using Forum.UI.Web.Models;

namespace Forum.UI.Web
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		protected static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",                                              // Route name
				"{controller}/{action}/{id}",                           // URL with parameters
				new { controller = "Question", action = "Index", id = "" }  // Parameter defaults
			);

		}

		protected ISessionFactory SessionFactory { get; set; }

		public static ISession CurrentSession { get { return (HttpContext.Current.ApplicationInstance as MvcApplication).SessionFactory.GetCurrentSession(); } }

		protected void RegisterNHibernate()
		{
			var config = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2005.ConnectionString(x => x.Is(ConfigurationManager.ConnectionStrings["Forum"].ConnectionString)))
				.Mappings(x => x.AutoMappings.Add(AutoMap.Assembly(Assembly.Load("Forum.UI.Web")).Where(t => t.Namespace == "Forum.UI.Web.Models")))
				.ExposeConfiguration(x => x.SetProperty("current_session_context_class", "web"))
				.BuildConfiguration();

			SessionFactory = config.BuildSessionFactory();

			this.BeginRequest += delegate { CurrentSessionContext.Bind(SessionFactory.OpenSession()); };
			this.EndRequest += delegate { 
				var session = CurrentSessionContext.Unbind(SessionFactory);

				if (session != null)
					session.Dispose();
			};

			//Install(config);
		}

		private void Install(NHibernate.Cfg.Configuration config)
		{
			var SchemaExport = new NHibernate.Tool.hbm2ddl.SchemaExport(config);
			SchemaExport.Drop(false, true);
			SchemaExport.Create(false, true);

			using (var session = config.BuildSessionFactory().OpenSession())
			{
				session.Save(new Question() { Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. ", Started = DateTime.Now });
				session.Flush();
			}

		}

		static MvcApplication()
		{
			RegisterRoutes(RouteTable.Routes);
		}

		public MvcApplication()
		{
			RegisterNHibernate();
		}
	}
}