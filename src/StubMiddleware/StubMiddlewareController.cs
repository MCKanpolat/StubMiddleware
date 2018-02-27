using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StubGenerator.Core;

namespace StubMiddleware
{
    [Route("StubMiddleware")]
    public class StubMiddlewareController : Controller
    {
        private readonly IStubManager _stubManager;

        public StubMiddlewareController(IStubManager stubManager) =>
            _stubManager = stubManager ?? throw new ArgumentNullException(nameof(stubManager));


        [HttpGet, Route("list")]
        public async Task<IActionResult> list([FromQuery]string className, [FromQuery]int listSize, [FromQuery]int subItemlistSize, [FromQuery]string culture)
        {
            if (!string.IsNullOrWhiteSpace(culture))
            {
                var cultureInfo = new CultureInfo(culture);
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;
            }
            var instance = _stubManager.InvokeCreateListOfSize(className, listSize, subItemlistSize == 0 ? 3 : subItemlistSize);
            if (instance == null)
            {
                return NotFound(className);
            }
            return Ok(instance);
        }


        [HttpGet, Route("get")]
        public async Task<IActionResult> get([FromQuery]string className, [FromQuery]int subItemlistSize, [FromQuery]string culture)
        {
            if (!string.IsNullOrWhiteSpace(culture))
            {
                var cultureInfo = new CultureInfo(culture);
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;
            }

            var instance = _stubManager.InvokeCreateNew(className, subItemlistSize == 0 ? 3 : subItemlistSize);
            if (instance == null)
            {
                return NotFound(className);
            }
            return Ok(instance);
        }
    }
}
