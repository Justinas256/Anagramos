using Anagrams.EFCF.Core.Context;
using Implementation.AnagramSolver;
using Implementation.AnagramSolver.Database;
using Interfaces.AnagramSolver;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web.App_Start;

namespace Web
{
    public class MvcApplication : HttpApplication
    {

        protected void Application_Start()
        {
            IocConfig.ConfigureDependencyInjection();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            /*
            using (var context = new AnagramCFContext())
            {
                var cachedWord = new Anagrams.EFCF.Core.Model.CachedWord() { CachedWord1 = "labas" };
                context.CachedWords.Add(cachedWord);
                context.SaveChanges();
            }
            */

       

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
