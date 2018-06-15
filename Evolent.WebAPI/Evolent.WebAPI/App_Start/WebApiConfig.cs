using Evolent.DataAccess.Infrastructure;
using Evolent.DataAccess.Repositories;
using Evolent.DataAccess.UnitOfWork;
using Evolent.Services.Interface;
using Evolent.Services.Component;
using System.Web.Http;
using Evolent.WebAPI.Resolver;
using SimpleInjector;

namespace Evolent.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();

            container.Register<IContactRepository, ContactRepository>();
            container.Register<IConnectionFactory, ConnectionFactory>();
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IContact, Contact>();
            //container.Verify();
            config.DependencyResolver = new UnityResolver(container);
            


            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
