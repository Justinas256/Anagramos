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
        public static IAnagramSolver Solver;
        public static IWordRepository Reader;
        public static CachedWordsService CachedWordService;
        public static UserLogService UsersLogService;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //string path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            //string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            string path = AppConfig.FilePath;
            string connectionString = AppConfig.ConnectionString;
            try {
                //IWordRepository reader = new FileReader(path);
                Reader = new DatabaseRepository(connectionString);
                Solver = new OneWordFinder(Reader.GetData());
                CachedWordService = new CachedWordsService(new CachedWordsRepository(connectionString));
                UsersLogService = new UserLogService(new UserLogRepository(connectionString));
            } catch { }

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
