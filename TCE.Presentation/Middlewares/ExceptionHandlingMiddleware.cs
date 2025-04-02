public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var response = exception switch
        {
            FluentValidation.ValidationException validationException => new ErrorResponse(
                StatusCodes.Status400BadRequest,
                "Erro de validação",
                validationException.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}")
            ),

            KeyNotFoundException => new ErrorResponse(
                StatusCodes.Status404NotFound,
                "Recurso não encontrado",
                new[] { exception.Message }
            ),

            _ => new ErrorResponse(
                StatusCodes.Status500InternalServerError,
                "Erro interno no servidor",
                new[] { "Ocorreu um erro inesperado." }
            )
        };

        context.Response.StatusCode = response.StatusCode;
        return context.Response.WriteAsJsonAsync(response);
    }
}
public record ErrorResponse(int StatusCode, string Title, IEnumerable<string> Errors);
