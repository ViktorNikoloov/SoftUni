using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using HttpStatusCode = SIS.HTTP.Enums.HttpStatusCode;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {
        IList<Route> routeTable;

        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
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
                int count = await stream.ReadAsync(buffer, position, buffer.Length);
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


            HttpResponse response;
            var route = routeTable
                .FirstOrDefault(x => string.Compare(x.Path, request.Path,true) == 0 &&
                x.Method == request.Method);
            if (route != null)
            {
                response = route.Action(request);
            }
            else
            {
                //var responseHtml = $"<h1>{(int)(HttpStatusCode.NotFound)} {HttpStatusCode.NotFound}</h1>";
                //var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
                response = new HttpResponse("text/html", Array.Empty<byte>(), HttpStatusCode.NotFound);
            }
            Console.WriteLine((int)(response.StatusCode) + " " + response.StatusCode.ToString());


            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
            { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });
            response.Headers.Add(new Header("Server", "SIS Server 1.0"));
           
            var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());
            await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
            await stream.WriteAsync(response.Body, 0, response.Body.Length);

           // tcpClient.Close();
        }
    }
}
