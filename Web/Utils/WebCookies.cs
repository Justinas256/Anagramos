using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Utils
{
    public static class WebCookies
    {

        public static void AddNewWordToHistory(HttpRequestBase request, HttpResponseBase response, string word)
        {
            List<string> lastAnagrams;
            if (request.Cookies["lastAnagram"] != null)
            {
                lastAnagrams = request.Cookies["lastAnagram"].Value.Split(',').ToList();
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
            response.Cookies["lastAnagram"].Value = lastAnagramsString;
            response.Cookies["lastAnagram"].Expires = DateTime.Now.AddDays(1);
        }
    }
}