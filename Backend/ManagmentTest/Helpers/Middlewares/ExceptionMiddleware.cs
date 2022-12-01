﻿using Helpers.GlobalEntities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Helpers.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var responseError = new ApiResponse();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            responseError.Status = (int)HttpStatusCode.InternalServerError;

            if (IsValidationException(context, exception, responseError))
                return context.Response.WriteAsync(responseError.ToJson());

            if (IsExceptionBase(context, exception, responseError))
                return context.Response.WriteAsync(responseError.ToJson());

            responseError.Message = exception.ToString();
            return context.Response.WriteAsync(responseError.ToJson());
        }

        private bool IsValidationException(
            HttpContext context,
            Exception exception,
            ApiResponse responseError)
        {
            var result = exception.GetType() == typeof(ValidationException);

            if (!result) return result;
            var validationException = (ValidationException)exception;
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            responseError.Status = (int)HttpStatusCode.BadRequest;
            responseError.Message = validationException.Message;
            return result;
        }

        private static bool IsExceptionBase(
            HttpContext context,
            Exception exception,
            ApiResponse responseError)
        {
            var result = exception.GetType().BaseType == typeof(ExceptionBase);

            if (!result) return result;

            var exceptionBase = (ExceptionBase)exception;
            responseError.Status = (int)HttpStatusCode.OK;
            responseError.Message = exceptionBase.Message;
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            return result;
        }
    }
}
