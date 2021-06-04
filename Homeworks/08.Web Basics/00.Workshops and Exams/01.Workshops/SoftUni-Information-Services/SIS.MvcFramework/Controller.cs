using System.Runtime.CompilerServices;
using System.Text;

using SIS.HTTP;
using SIS.MvcFramework.ViewEngine;

namespace SIS.MvcFramework
{
    public abstract class Controller
    {
        private SisViewEngine viewEngine;

        public Controller()
        {
            viewEngine = new SisViewEngine();
        }

        public HttpRequest Request { get; set; }

        public HttpResponse View(object viewModel = null,
            [CallerMemberName] string viewPath = null)
        {
            var viewContent = System.IO.File
                .ReadAllText($"Views/{this.GetType().Name.Replace("Controller", string.Empty)}/{viewPath}.cshtml");
            viewContent = viewEngine.GetHtml(viewContent, viewModel);

            var responseHtml = PutViewInLayout(viewContent, viewModel);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }



        public HttpResponse File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);

            return response;
        }

        public HttpResponse Redirect(string url)
        {
            // post => 302 => get
            // post => 307 => post
            var response = new HttpResponse(HTTP.Enums.HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));

            return response;
        }

        public HttpResponse Error(string errorText)
        {
            var viewContent = $"<div class=\"alert alert-danger\" role=\"alert\">{errorText}</div ";
            var responseHtml = PutViewInLayout(viewContent);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes, HTTP.Enums.HttpStatusCode.ServerError);

            return response;
        }

        private string PutViewInLayout(string viewContent, object viewModel = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");
            layout = layout.Replace("@RenderBody()", "____VIEW_GOES_HERE____");
            layout = viewEngine.GetHtml(layout, viewModel);
            var responseHtml = layout.Replace("____VIEW_GOES_HERE____", viewContent);

            return responseHtml;
        }
    }
}
