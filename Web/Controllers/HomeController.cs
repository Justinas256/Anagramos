using Implementation.AnagramSolver;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using System.Linq;
using Implementation.AnagramSolver.Database;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        IAnagramSolver Solver;
        IWordRepository Reader;
        CachedWordsService CachedWordService;
        UserLogService UsersLogService;

        public HomeController()
        {
            Solver = MvcApplication.Solver;
            Reader = MvcApplication.Reader;
            CachedWordService = MvcApplication.CachedWordService;
            UsersLogService = MvcApplication.UsersLogService;
        }

        public HomeController(IAnagramSolver solver)
        {
            Solver = solver;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anagram(String word)
        { 
            //cookies - last searched words
            List<string> lastAnagrams;
            if (Request.Cookies["lastAnagram"] != null)
            {
                lastAnagrams = Request.Cookies["lastAnagram"].Value.Split(',').ToList();
                if (lastAnagrams.Count >= 5)
                    lastAnagrams.RemoveAt(0);
                if (!lastAnagrams.Contains(word))
                    lastAnagrams.Add(word);
            }
            else
            {
                lastAnagrams = new List<string>();
                lastAnagrams.Add(word);
            }
            var lastAnagramsString = String.Join(",", lastAnagrams);
            Response.Cookies["lastAnagram"].Value = lastAnagramsString;
            Response.Cookies["lastAnagram"].Expires = DateTime.Now.AddDays(1);

            //find anagrams -- find if there are cached words
            List<string> anagrams = CachedWordService.FindCachedAnagramsString(word);
            if(anagrams == null)
            {
                anagrams = Solver?.FindWords(new List<String>() { word });
                CachedWordService.InsertCashedWords(word, anagrams);
            }

            //UserLog
            string ip = Request.UserHostAddress;
            DateTime time = DateTime.Now;
            UsersLogService.AddNewLog(ip, time, word);

            ViewBag.Anagrams = anagrams; 
            return View("Index");
        }

        public ActionResult FindWord(String word)
        {
            ViewBag.Words = Reader?.GetFilteredWords(word);
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

    }
}