using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Delay(5000); // give it time for website to fire

            RunAsync().Wait();

            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }

        static async Task RunAsync() {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53402/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("Home/Get/1");
                if (response.IsSuccessStatusCode)
                {
                    var vm = await response.Content.ReadAsAsync<SameViewModelButDifferentName>();
                    Console.WriteLine("{0}|{1}|{2}", vm.Name, vm.State, vm.Url);
                }

                response = await client.GetAsync("Home/Get/2");
                if (response.IsSuccessStatusCode)
                {
                    var vm = await response.Content.ReadAsAsync<SameViewModelButDifferentName>();
                    Console.WriteLine("{0}|{1}|{2}", vm.Name, vm.State, vm.Url);
                }

                response = await client.GetAsync("Home/Get/3");
                if (response.IsSuccessStatusCode)
                {
                    var vm = await response.Content.ReadAsAsync<SameViewModelButDifferentName>();
                    Console.WriteLine("{0}|{1}|{2}", vm.Name, vm.State, vm.Url);
                }
            }
        }
    }

    public class SameViewModelButDifferentName
    {
        public string State { get; set; }
        public string Url { get; set; }
        public string Name { get; set; } 
    }
}
