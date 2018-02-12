using Implementation.AnagramSolver;
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
        public static IAnagramSolver Solver;
        public static IWordRepository Reader;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            string path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            try {
                //IWordRepository reader = new FileReader(path);
                Reader = new DatabaseRepository(connectionString);
                Solver = new OneWordFinder(Reader.GetData());
            } catch { }

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
