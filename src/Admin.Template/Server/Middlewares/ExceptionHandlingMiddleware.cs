using System.Net;

namespace Admin.Template.Server.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
	{
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next.Invoke(context);
        }
		catch (Exception ex)
		{
            logger.LogError(ex, ex.Message);

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await response.WriteAsync(ex.Message);
        }
    }
}
