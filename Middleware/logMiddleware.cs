using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Security.Claims;

public class logMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<logMiddleware> logger;

    public logMiddleware(RequestDelegate next, ILogger<logMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var startTime = DateTime.UtcNow;  // זמן התחלה
        var stopwatch = Stopwatch.StartNew();

        var routeData = context.GetRouteData();
        var controller = routeData.Values["controller"];
        var action = routeData.Values["action"];

        // Get logged-in user
        var userName = context.User?.FindFirst(ClaimTypes.Name)?.Value ?? "Anonymous";

        // Process the request
        await next(context);

        stopwatch.Stop();
        var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

        // Log the request details
        logger.LogInformation("Request: {Controller}/{Action} by User: {UserName}. Start Time: {StartTime}, Duration: {Duration}ms",
            controller, action, userName, startTime, elapsedMilliseconds);
    }
}
