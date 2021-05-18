using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.HttpClientDemo
{
    class Program
    {
        const string NewLine = "\r\n";

        static async Task Main(string[] args)
        {
            //await ReadData();

            Console.OutputEncoding = Encoding.UTF8;
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80); // default local port:80 ! // default https port: 443 !
            tcpListener.Start();

            //demon //service
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                ProcessClientAsync(client);
            }

            Console.ReadLine();
        }

        public static async Task ProcessClientAsync(TcpClient client)
        {
            using var stream = client.GetStream();

            byte[] buffer = new byte[1000000]; // The byte[] lenght is only for the demo
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var lenght = await stream.ReadAsync(buffer, 0, buffer.Length);

            string requestString = Encoding.UTF8.GetString(buffer, 0, lenght);

            Console.WriteLine(requestString);

            Thread.Sleep(5000);

            string html = $"<h1>Hello from ViktorServer {DateTime.UtcNow}</h1>";
            string signUpForm = $"<form method=post><input name=Username /><input name=Password />" +
                $"<input type=Submit /></form>"; //No personal data in the Url when we use post method !

            /*Contetnt-Types: text/html, image/png, text/plain, application/xml, application/pdf, and more*/
            string responseOk = "HTTP/1.1 200 OK" + NewLine +
                "Server: ViktorServer 2021" + NewLine +
                "Content-Type: text/html; charset=utf-8" + NewLine +
                "Content-Lenght:" + html.Length + NewLine +
                NewLine +
                html + NewLine + signUpForm + NewLine;

            string responseRedirect = "HTTP/1.1 307 Redirect" + NewLine +
                "Server: ViktorServer 2021" + NewLine +
                "Location: https://www.google.bg/" + NewLine +
                "Content-Type: text/html; charset=utf-8" + NewLine +
                "Content-Lenght:" + html.Length + NewLine +
                NewLine +
                html + NewLine;

            string responseDisposition = "HTTP/1.1 200 OK" + NewLine +
                "Server: ViktorServer 2021" + NewLine +
                "Content-Type: text/plain; charset=utf-8" + NewLine +
                "Content-Disposition: attachment; filename=Viktor.txt" + NewLine +
                "Content-Lenght:" + html.Length + NewLine +
                NewLine +
                html + NewLine + signUpForm + NewLine;

            byte[] responseOkByte = Encoding.UTF8.GetBytes(responseOk);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            //byte[] responseRedirectByte = Encoding.UTF8.GetBytes(responseRedirect);
            //byte[] responseDispositionByte = Encoding.UTF8.GetBytes(responseDisposition);

            await stream.WriteAsync(responseOkByte);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            //stream.WriteAsync(responseRedirectByte);
            //stream.WriteAsync(responseDispositionByte);

            Console.WriteLine(new string('=', 70));
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("X-Client-Version", "1.0");
            //httpClient.DefaultRequestHeaders.Add("X-Test", "test...");

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var response = await httpClient.GetAsync(url);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            //var html = await httpClient.GetStringAsync(url);
            //Console.WriteLine(html);
        }
    }

}
