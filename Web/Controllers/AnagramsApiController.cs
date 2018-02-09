using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{

    public class AnagramsApiController : ApiController
    {
        IAnagramSolver Solver;

        [HttpGet]
        public IHttpActionResult AnagramText(String word)
        {
            Solver = MvcApplication.Solver;
            var toFind = new List<String>() { word };
            var foundedAnagrams = new List<String>() { word };
            if (Solver != null)
                foundedAnagrams = Solver.FindWords(toFind);
            if (foundedAnagrams == null || foundedAnagrams.Count == 0)
                return Ok("No anagrams were founded");
            else
                return Ok("Founded: " + string.Join(", ", foundedAnagrams));
        }

    }
}