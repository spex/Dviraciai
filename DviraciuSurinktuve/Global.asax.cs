using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using FluentNHibernate.Cfg;
using FluentNHibernate.Automapping;
using DviraciuSurinktuve.Models;
using DviraciuSurinktuve.Entities;
using FluentNHibernate.Conventions;
using System.Reflection;
using FluentNHibernate;
using DviraciuSurinktuve.Entities.Mappings;

namespace DviraciuSurinktuve
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        public static ISessionFactory SessionFactory { get; private set; }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            var scfg = new StoreConfiguration();
            var config = new Configuration();
            config.Configure();

            SessionFactory = config.BuildSessionFactory();
            SessionFactory = Fluently.Configure(config)
            .Database(FluentNHibernate.Cfg.Db.JetDriverConfiguration.Standard)
            .Mappings(m => m.FluentMappings
                 .AddFromAssemblyOf<DetalėMapping>()
                 .AddFromAssemblyOf<DetaliųGrupėMapping>()
            )
            .BuildSessionFactory();
            /* SessionFactory = Fluently.Configure()
 .Database(FluentNHibernate.Cfg.Db.JetDriverConfiguration.Standard
         .ConnectionString(x => x.DatabaseFile(@"\web\test.accdb")))
*/

        }
       

        public class NHibernateSessionModule : IHttpModule
        {
            public void Dispose()
            {
            }
            public void Init(HttpApplication context)
            {
                context.BeginRequest +=
                    delegate
                    {
                        var session = MvcApplication.SessionFactory.OpenSession();
                        CurrentSessionContext.Bind(session);
                    };
                context.EndRequest +=
                    delegate
                    {
                        CurrentSessionContext.Unbind(MvcApplication.SessionFactory);
                    };
            }
        }



    }
    
}