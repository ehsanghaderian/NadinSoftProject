using Application.Exceptions;
using DomainModel.Exceptions;
using NadinSoftProject.Host.Messages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace NadinSoftProject.Host.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException exception)
            {
                await ConfigureResponse(context, HttpStatusCode.BadRequest, exception.Message);
            }

            catch (ApplicationServiceNotFoundException exception)
            {
                await ConfigureResponse(context, HttpStatusCode.NotFound, exception.Message);
            }

            catch (ApplicationServiceBadRequestException exception)
            {   
                await ConfigureResponse(context, HttpStatusCode.BadRequest, exception.Message);
            }

            catch (ApplicationServiceForbiddenException exception)
            {
                await ConfigureResponse(context, HttpStatusCode.Forbidden, exception.Message);
            }

            catch (DomainServiceException exception)
            {
                await ConfigureResponse(context, HttpStatusCode.InternalServerError, exception.Message);
            }

            catch (Exception exception)
            {
                await ConfigureResponse(context, HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        private static async Task ConfigureResponse(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(new ResponseMessage(message).ToString());
        }
    }

}
