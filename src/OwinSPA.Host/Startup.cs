using System.Web.Http;
using Autofac.Integration.WebApi;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using OwinSPA.Host.Infrastructure.IoC;

namespace OwinSPA.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

#if DEBUG
            var physicalFileSystem = new PhysicalFileSystem(@"..\..\web");
#else
            var physicalFileSystem = new PhysicalFileSystem("web");
#endif

            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };

            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[]
            {
                "index.html"
            };

            appBuilder.UseFileServer(options);

            var autofacContainer = Bootstrapper.Init();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(autofacContainer);

            appBuilder.UseAutofacMiddleware(autofacContainer);
            appBuilder.UseAutofacWebApi(config);
            appBuilder.UseWebApi(config);
        }
    }
}
