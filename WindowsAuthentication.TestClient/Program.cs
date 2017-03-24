using System;
using System.Net.Http;

namespace WindowsAuthentication.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {

            // note: passing a handler with following config option allows us to attach our windows credentials with the web api call later...
            var handler = new HttpClientHandler
            {
                UseDefaultCredentials = true
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:44330/api/")
            };

            // call the "identity" controller, for test purpose we aren't awaiting the response here...
            var response = client.GetAsync("identity").Result;
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}
