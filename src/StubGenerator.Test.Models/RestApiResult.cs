using System.Collections.Generic;

namespace StubGenerator.Test.Models
{
    public class RestApiResult
    {
        public RestApiResult()
        {
            Links = new List<LinkInfo>();
        }
        public List<LinkInfo> Links { get; set; }
    }


    public class LinkInfo
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}
