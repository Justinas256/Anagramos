using Implementation.AnagramSolver;
using Interfaces.AnagramSolver;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : HttpApplication
    {
        public static IAnagramSolver Solver;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            string path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            try { 
                IWordRepository fileReader = new FileReader(path);
                Solver = new OneWordFinder();
                Solver.Init(fileReader.GetData());
            } catch { }

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
