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
        UserLogService UsersLogService;

        public UserLogsController(UserLogService usersLogService)
        { 
            UsersLogService = usersLogService;
        }

        public ViewResult Logs(int? page)
        {
            List<UserLogFull> userLogs = UsersLogService.GetAllLogsAndAnagrams();
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(userLogs.ToPagedList(pageNumber, pageSize));
        }
    }
}