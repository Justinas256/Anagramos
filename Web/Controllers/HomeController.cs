using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using System.Linq;
using System.Net;
using Web.Utils;
using Anagram.Core;
using System.Threading.Tasks;

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
        public async Task<ViewResult> Anagram(String word)
        {
            string ip = LogActivities.GetIPAddress();

            if (UsersLogService.IsPermittedToView(ip))
            {
                //cookies - last searched words
                WebCookies.AddNewWordToHistory(Request, Response, word);
                //find anagrams -- find if there are cached words
                //List<string> anagrams = CachedWordService.FindAnagrams(word);
                List<string> anagrams = await Task.Run(() => (CachedWordService.FindAnagrams(word)));
                ViewBag.Anagrams = anagrams;
                //UserLog
                Task.Run(() => LogActivities.LogWordViewed(word));
            }
            else
            {
                ViewBag.Permitted = false;
            }
            return View("Index");
        }

        public async Task<ViewResult> FindWord(String word)
        {
            ViewBag.Words = await Task.Run(() => WordsService.GetFilteredWords(word));
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
        public async Task<FileResult> DownloadAnagrams()
        {
            byte[] fileBytes = await Task.Run(() => System.IO.File.ReadAllBytes(AppConfig.FilePath));
            string fileName = "anagrams.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

       

    }
}