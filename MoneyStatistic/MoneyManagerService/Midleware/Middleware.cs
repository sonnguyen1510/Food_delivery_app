namespace MoneyManagerService.Midleware
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Perform some actions before the request reaches the controller
            // For example, you can log, modify the request, or check for specific conditions.

            await _next(context);

            // Perform some actions after the request has been processed by the controller
            // For example, you can modify the response or perform additional tasks.
        }
    }
}
