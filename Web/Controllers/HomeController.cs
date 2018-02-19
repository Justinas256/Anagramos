using Implementation.AnagramSolver;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using System.Linq;
using Implementation.AnagramSolver.Database;
using System.Net;
using Implementation.AnagramSolver.Services;
using Web.Utils;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        IAnagramSolver Solver;
        WordsService WordsService;
        CachedWordsService CachedWordService;
        UserLogService UsersLogService;
        LogActivity LogActivities;

        /*
        public HomeController()
        {
            Solver = Dependencies.Solver;
            Reader = Dependencies.WordRepository;
            CachedWordService = Dependencies.CachedWordService;
            UsersLogService = Dependencies.UsersLogService;
        }
        */

        public HomeController(IAnagramSolver solver, WordsService wordsService, CachedWordsService cachedWordService, UserLogService usersLogService)
        {
            Solver = solver;
            WordsService = wordsService;
            CachedWordService = cachedWordService;
            UsersLogService = usersLogService;
            LogActivities = new LogActivity(UsersLogService);
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
            ViewBag.Words = WordsService?.GetFilteredWords(word);
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
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\justinas.antanaviciu\source\repos\Anagramos\Anagramos\zodynas.txt");
            string fileName = "anagrams.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

       

    }
}