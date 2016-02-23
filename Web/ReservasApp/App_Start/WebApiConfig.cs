using Autofac;
using Autofac.Integration.WebApi;
using BaseDataLayer;
using DataLayer.DbContext;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Repositories;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using ReservasApp.Identity;

namespace ReservasApp
{
    public static class WebApiConfig
    {
        public static IContainer Container {get; set;}

        public static void Register(HttpConfiguration config)
        {

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            //Autofac 
            var builder = new ContainerBuilder();
            //Generic
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerLifetimeScope();
            //Context
            builder.RegisterType<ReservasContext>().As<IReservasContext>();
            //Repositories
            builder.RegisterType<ComplejoRepository>().As<IComplejoRepository>();
            //Services
            builder.RegisterType<ComplejoService>().As<IComplejoService>();
            //Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //Domain Login Provider
            builder.RegisterInstance(new DomanUserLoginProvider("vp"))
                .As<ILoginProvider>()
                .SingleInstance();

            //Local machine Login Provider - descomentar estas lineas para utilizar login local
            //builder.RegisterType<LocalUserLoginProvider>()
            //    .As<ILoginProvider>()
            //    .SingleInstance();


            Container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(Container);
            config.DependencyResolver = resolver;

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);



        }

    }
}
