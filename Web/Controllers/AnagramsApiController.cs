using Anagram.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web.Controllers
{

    public class AnagramsApiController : ApiController
    {
        IAnagramSolver Solver;

        public AnagramsApiController(IAnagramSolver solver)
        {
            Solver = solver;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAnagram(String word)
        {
            List<String> foundedAnagrams = await Solver.FindWordsAsync(new List<String>() { word });

            if (foundedAnagrams == null || !foundedAnagrams.Any())
                return Ok("No anagrams were founded");
            else
                return Ok("Founded: " + string.Join(", ", foundedAnagrams));
        }

    }
}