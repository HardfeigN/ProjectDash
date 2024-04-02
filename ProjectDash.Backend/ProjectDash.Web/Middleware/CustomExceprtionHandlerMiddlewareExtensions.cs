namespace ProjectDash.Web.Middleware
{
    public static class CustomExceprtionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceprtionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomExceprtionHandlerMiddleware>();
        }
    }
}
