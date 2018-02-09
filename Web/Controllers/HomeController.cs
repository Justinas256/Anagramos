using Implementation.AnagramSolver;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using System.Linq;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        IAnagramSolver Solver;

        public HomeController()
        {
            Solver = MvcApplication.Solver;
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

            ViewBag.Anagrams = Solver?.FindWords(new List<String>() { word });

            return View("Index");
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