﻿using Microsoft.AspNetCore.Mvc;
using StubGenerator.Test.Models;

namespace StubMiddleware.Web.Test.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var testModelNs = typeof(ComplexModel).FullName;
            var testModelAsmName = typeof(ComplexModel).Assembly.GetName().Name;
            var result = new RestApiResult();
            var url = Url.Action("get", "stubmiddleware", new { className = $"{testModelNs}, {testModelAsmName}", subItemlistSize = 3, culture = "en-us" });
            result.Links.Add(new LinkInfo() { Href = url, Method = "GET", Rel = "self" });

            var urlList = Url.Action("list", "stubmiddleware", new { className = $"{testModelNs}, {testModelAsmName}", subItemlistSize = 3, culture = "en-us", listSize = 10 });
            result.Links.Add(new LinkInfo() { Href = urlList, Method = "GET", Rel = "self" });

            return Ok(result);
        }
    }
}
