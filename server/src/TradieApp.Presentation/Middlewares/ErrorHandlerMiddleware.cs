using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using TradieApp.Application.Common.Exceptions;
using TradieApp.Application.Common.Wrappers;
using System.Text.Json;

namespace TradieApp.Presentation.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await response.WriteAsJsonAsync(new Response(e.Errors,e.Message));
                        return;
                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        await response.WriteAsJsonAsync(new Response(e.Message));
                        return;
                    case BadRequestException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await response.WriteAsJsonAsync(new Response(e.Message));
                        return;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await response.WriteAsJsonAsync(new Response("Internal Server Error"));
                        return;
                }
            }
        }
    }
}

