using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {
        

        IDictionary<string, Func<HttpRequest, HttpResponse>> routeTable =
            new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);

            }
        }

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener =
                new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using NetworkStream stream = tcpClient.GetStream();

            List<byte> data = new List<byte>();

            int position = 0;
            byte[] buffer = new byte[HttpConstants.BufferSize];
            while (true)
            {
                int count =
                await stream.ReadAsync(buffer, position, buffer.Length);
                position += count;

                if (count < buffer.Length)
                {
                    var partialBuffer = new byte[count];
                    Array.Copy(buffer, partialBuffer, count);
                    data.AddRange(partialBuffer);
                    break;
                }
                else
                {
                    data.AddRange(buffer);
                }
            }

            //byte[] => string => Encoding
            var requestAsString = Encoding.UTF8.GetString(data.ToArray());
            var request = new HttpRequest(requestAsString);
            Console.WriteLine($"{request.Method} {request.Path} => {request.Headers.Count} headers");

            var responseHtml = "<h1>Welcome!</h1>" +
                request.Headers.FirstOrDefault(x=>x.Name =="User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            response.Headers.Add(new Header("Server", "SIS Server 1.0"));
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString()) 
            { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });
            
            var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());
            await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
            await stream.WriteAsync(response.Body, 0, response.Body.Length);

            //tcpClient.Close();
        }
    }
}
