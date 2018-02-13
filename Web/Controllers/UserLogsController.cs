using Implementation.AnagramSolver;
using Implementation.AnagramSolver.Database;
using Implementation.AnagramSolver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Web.Controllers
{
    public class UserLogsController : Controller
    {
        // GET: UserLogs
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Logs(int? page)
        {
            UserLogService userService = new UserLogService(new UserLogRepository());
            List<UserLog> userLogs = userService.GetAllLogsAndAnagrams();
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(userLogs.ToPagedList(pageNumber, pageSize));
        }
    }
}