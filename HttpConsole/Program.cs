using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace HttpConsole
{
    class Program
    {

        static HttpClient client = new HttpClient();

        static async Task<string> GetAnogramAsync(string path, string word)
        {
            string anagram = "";
            HttpResponseMessage response = await client.GetAsync(path + "?word=" + word);

            if (response.IsSuccessStatusCode)
            {
                anagram = response.Content.ReadAsStringAsync().Result;
            }
            return anagram;
        }

        static async Task RunAsync(string data)
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:54566/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

            try
            {
                string anagram = await GetAnogramAsync("home/AnagramText", data);
                Console.WriteLine(anagram);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Write word: ");
            string word = Console.ReadLine();
            RunAsync(word).GetAwaiter().GetResult();
        }

    }
    
}
