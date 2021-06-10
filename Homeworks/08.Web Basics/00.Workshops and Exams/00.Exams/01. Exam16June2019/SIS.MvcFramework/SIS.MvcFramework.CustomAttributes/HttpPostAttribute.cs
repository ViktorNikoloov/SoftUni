using SIS.HTTP.Enums;

namespace SIS.MvcFramework.SIS.MvcFramework.CustomAttributes
{
    public class HttpPostAttribute : BaseHttpAttribute
    {
        public HttpPostAttribute()
        {

        }

        public HttpPostAttribute(string url)
        {
            Url = url;
        }

        public override HttpMethod Method => HttpMethod.Post;
    }
}
