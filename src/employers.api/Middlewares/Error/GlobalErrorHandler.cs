using employers.application.Exceptions.RegraNegocio;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace employers.api.Middlewares.Error
{
    [ExcludeFromCodeCoverage]
    public sealed class GlobalErrorHandler(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context, CancellationToken cancellationToken)
        {
            try
            {
                await next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    RegranegocioException _ => (int)HttpStatusCode.BadRequest,// custom application error
                    KeyNotFoundException _ => (int)HttpStatusCode.NotFound,// not found error
                    _ => (int)HttpStatusCode.InternalServerError,// unhandled error
                };
                var result = JsonSerializer.Serialize(new { message = error?.Message, success = false });
                await response.WriteAsync(result, cancellationToken);
            }
        }
    }
}
