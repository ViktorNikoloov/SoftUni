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

        public HttpResponse View(object viewModel = null,
            [CallerMemberName] string viewPath = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");
            layout = layout.Replace("@RenderBody()", "____VIEW_GOES_HERE____");
            layout = viewEngine.GetHtml(layout, viewModel);

            var viewContent = System.IO.File
                .ReadAllText($"Views/{this.GetType().Name.Replace("Controller", string.Empty)}/{viewPath}.cshtml");

            viewContent = viewEngine.GetHtml(viewContent, viewModel);

            var responseHtml = layout.Replace("____VIEW_GOES_HERE____", viewContent);

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
    }
}
