using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST
{
    class Program
    {
        //not finished
        static void Main(string[] args)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("posts", Method.GET);
            IRestResponse<List<Post>> response = client.Execute<List<Post>>(request);
            
            /*
            foreach(Post obj in response.Data)
            {
                Console.WriteLine("ID: " + obj.id);
                Console.WriteLine("User id: " + obj.userId);
                Console.WriteLine("Title: " + obj.title);
                Console.WriteLine("Body: " + obj.body);
            }
            */
            
            Console.ReadLine();
        }
    }
}
