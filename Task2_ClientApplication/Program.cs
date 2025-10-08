using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Task2_ClientApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Fetching products from the Web API...");

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => true
            };

            HttpClient client = new HttpClient(handler);

            try
            {
                // Replace with your actual API endpoint
                var response = await client.GetAsync("http://localhost:5014/api/employee");


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response from API:");
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception from API: {ex.Message}");
            }
        }
    }
}
