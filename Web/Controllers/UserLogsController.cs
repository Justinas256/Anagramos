using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Anagram.Core;
using Anagram.Core.Model;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class UserLogsController : Controller
    {
        IUserLogService UsersLogService;

        public UserLogsController(IUserLogService usersLogService)
        { 
            UsersLogService = usersLogService;
        }

        public async Task<ViewResult> Logs(int? page)
        {
            List<UserLogFull> userLogs = await Task.Run(() => UsersLogService.GetAllLogsAndAnagrams());
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(userLogs.ToPagedList(pageNumber, pageSize));
        }
    }
}