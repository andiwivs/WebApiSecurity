using System;
using System.Net.Http;

namespace KatanaAuthentication.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:50397/api/")
            };

            client.SetBasicAuthentication("anders", "anders"); // utilise Thinktecture.IdentityModel.Client utility package to deal with Basic auth header encoding and assignment

            // call the "identity" controller, for test purpose we aren't awaiting the response here...
            var response = client.GetAsync("identity").Result;
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}
