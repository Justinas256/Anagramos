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
        List<string> AllWords;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anagram(String word)
        {
            Solver = MvcApplication.Solver;
            var toFind = new List<String>() { word };
            if(Solver != null)
                ViewBag.Anagrams = Solver.FindWords(toFind); ;
            return View("Index");
        }

        public String AnagramText(String word)
        {
            Solver = MvcApplication.Solver;
            var toFind = new List<String>() { word };
            var foundedAnagrams = new List<String>() { word };
            if (Solver != null)
                foundedAnagrams = Solver.FindWords(toFind);
            if (foundedAnagrams == null || foundedAnagrams.Count == 0)
                return "No anagrams were founded";
            else 
                return "Founded" + string.Join(", ", foundedAnagrams);
        }

        public ViewResult Show(int? page)
        {
            AllWords = MvcApplication.Solver.AllWords;
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(AllWords.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Find()
        {
            return View("WordFormSerch");
        }

    }
}