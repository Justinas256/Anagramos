using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using System.Linq;
using System.Net;
using Web.Utils;
using Anagram.Core;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        IAnagramSolver Solver;
        IWordsService WordsService;
        ICachedWordsService CachedWordService;
        IUserLogService UsersLogService;
        LogActivity LogActivities;

        public HomeController(IAnagramSolver solver, IWordsService wordsService, ICachedWordsService cachedWordService, IUserLogService usersLogService)
        {
            Solver = solver;
            WordsService = wordsService;
            CachedWordService = cachedWordService;
            UsersLogService = usersLogService;
            LogActivities = new LogActivity(usersLogService);
        }

        public ActionResult Index()
        {
            return View();
        }

        //find word anagrams
        public ActionResult Anagram(String word)
        {
            string ip = LogActivities.GetIPAddress();

            if (UsersLogService.IsPermittedToView(ip))
            {
                //cookies - last searched words
                WebCookies.AddNewWordToHistory(Request, Response, word);
                //find anagrams -- find if there are cached words
                List<string> anagrams = CachedWordService.FindAnagrams(word);
                ViewBag.Anagrams = anagrams;
                //UserLog
                LogActivities.LogWordViewed(word);
            }
            else
            {
                ViewBag.Permitted = false;
            }
            return View("Index");
        }

        public ActionResult FindWord(String word)
        {
            ViewBag.Words = WordsService.GetFilteredWords(word);
            return View("Search");
        }

        //show all words
        [Route("home/anagrams/{page:int:min(1)=1}")]
        public ViewResult Show(int? page)
        {
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(Solver.AllWords.ToPagedList(pageNumber, pageSize));
        }

        //page to search for a word
        public ViewResult Find()
        {
            return View("WordFormSerch");
        }

        //download all anagrams in .txt file
        public FileResult DownloadAnagrams()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(AppConfig.FilePath);
            string fileName = "anagrams.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

       

    }
}