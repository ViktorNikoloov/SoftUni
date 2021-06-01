using System;

using SIS.HTTP.Enums;

namespace SIS.MvcFramework.SIS.MvcFramework.CustomAttributes
{
    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract HttpMethod Method{ get; }
    }
}
