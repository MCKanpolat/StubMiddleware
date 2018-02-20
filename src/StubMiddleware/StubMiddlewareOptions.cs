using StubGenerator.Core;

namespace StubMiddleware
{
    public sealed class StubMiddlewareOptions : StubManagerOptions
    {
        public string Route { get; set; } = "/stubgenerator";
    }
}
