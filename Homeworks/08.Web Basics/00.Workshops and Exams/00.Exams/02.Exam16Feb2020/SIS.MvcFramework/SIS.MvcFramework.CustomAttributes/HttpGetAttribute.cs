using SIS.HTTP.Enums;

namespace SIS.MvcFramework.SIS.MvcFramework.CustomAttributes
{
    public class HttpGetAttribute : BaseHttpAttribute
    {
        public HttpGetAttribute()
        {

        }

        public HttpGetAttribute(string url)
        {
            Url = url;
        }
        public override HttpMethod Method => HttpMethod.Get;
    }
}
