using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _01.HttpClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadData());
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string url = "https://softuni.bg/trainings/3353/csharp-web-basics-basics-may-2021/internal";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Test", "test...");
            var html = await httpClient.GetStringAsync(url);
            Console.WriteLine(html);
        }
    }

}
