using Implementation.AnagramSolver;
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

        /*
        public AnagramsApiController()
        {
            Solver = Dependencies.Solver;
        }
        */

        public AnagramsApiController(IAnagramSolver solver)
        {
            Solver = solver;
        }

        [HttpGet]
        public IHttpActionResult GetAnagram(String word)
        {
            List<String> foundedAnagrams = Solver?.FindWords(new List<String>() { word });
            if (foundedAnagrams == null || !foundedAnagrams.Any())
                return Ok("No anagrams were founded");
            else
                return Ok("Founded: " + string.Join(", ", foundedAnagrams));
        }

    }
}