using Microsoft.Extensions.Primitives;
using Serilog.Context;

namespace StoreAppMVC.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private const string HEADER = "X-Correlation-Id";
        private RequestDelegate _next;

        public RequestLoggingMiddleware(
         RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext ctx)
        {
            var cId = GetCorrelationId(ctx);

            using (LogContext.PushProperty(
             "CorrelationId", cId))
            {
                return _next.Invoke(ctx);
            }
        }

        private static string GetCorrelationId(
         HttpContext ctx)
        {
            ctx.Request.Headers.TryGetValue(
              HEADER, out StringValues cId);

            return cId.FirstOrDefault() ?? ctx.TraceIdentifier;
        }
    }
}
