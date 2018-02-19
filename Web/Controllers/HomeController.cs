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
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anagram(String word)
        {
            string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();

            if (UsersLogService.IsPermittedToView(ip))
            {
                //cookies - last searched words
                WebCookies cookies = new WebCookies();
                cookies.AddNewWordToHistory(Request, Response, word);

                //find anagrams -- find if there are cached words
                List<string> anagrams = CachedWordService.FindAnagrams(word);
                ViewBag.Anagrams = anagrams;

                //UserLog
                DateTime time = DateTime.Now;
                UsersLogService.AddNewLogView(ip, time, word);                
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

        [Route("home/anagrams/{page:int:min(1)=1}")]
        public ViewResult Show(int? page)
        {
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(Solver.AllWords.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Find()
        {
            return View("WordFormSerch");
        }

        public FileResult DownloadAnagrams()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\justinas.antanaviciu\source\repos\Anagramos\Anagramos\zodynas.txt");
            string fileName = "anagrams.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult AddWord(String word)
        {
            if(word != null && word.Length > 1)
            {
                try
                {
                    WordsService.AddNewWord(word);
                    ViewBag.Added = true;

                    string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    DateTime time = DateTime.Now;
                    UsersLogService.AddNewLogAdded(ip, time, word);
                }
                catch
                {
                    ViewBag.Added = false;
                }
            }
            return View("ManageWords");
        }

        public ActionResult DeleteWord(String word)
        {
            if (word != null && word.Length > 1)
            {
                try
                {
                    WordsService.DeleteWord(word);
                    ViewBag.Deleted = true;

                    string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    DateTime time = DateTime.Now;
                    UsersLogService.AddNewLogDeleted(ip, time, word);
                }
                catch
                {
                    ViewBag.Deleted = false;
                }
            }
            return View("ManageWords");
        }

        public ActionResult UpdateWord(String oldWord, String newWord)
        {
            if (oldWord != null && oldWord.Length > 1 && newWord != null && newWord.Length > 1)
            {
                try
                {
                    WordsService.UpdateWord(oldWord, newWord);
                    ViewBag.Updated = true;

                    string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    DateTime time = DateTime.Now;
                    UsersLogService.AddNewLogUpdated(ip, time, newWord);
                }
                catch
                {
                    ViewBag.Updated = false;
                }
            }
            return View("ManageWords");
        }

        public ViewResult ManageWords()
        {
            return View();
        }

    }
}