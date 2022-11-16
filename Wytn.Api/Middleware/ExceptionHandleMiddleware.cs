using System;
using System.Threading.Tasks;

using Wytn.Sys.Model.Dto;
using Wytn.Util.Exception;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Wytn.Api.Middleware
{
    /// <summary>
    /// 例外處理中介程式
    /// </summary>
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <returns>Task</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        /// <summary>
        /// 客製 Exception 傳回的訊息格式
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            object result;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            if (exception is BusinessException)
            {
                result = new ResponseMessage
                {
                    status = 500,
                    message = exception.Message,
                    timestamp = DateTime.Now.Ticks
                };
            }
            else
            {
                result = new ResponseMessage
                {
                    status = 500,
                    message = "Internal Server Error.",
                    timestamp = DateTime.Now.Ticks
                };
            }
            return context.Response.WriteAsJsonAsync(result);
        }
    }

    /// <summary>
    /// 在中介程式中全域處理例外
    /// </summary>
    public static class ExceptionHandleMiddlewareExtensions
    {
        /// <summary>在中介程式中全域處理例外</summary>
        /// <param name="builder">中介程式建構器</param>
        /// <returns>IApplicationBuilder</returns>
        public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandleMiddleware>();
        }
    }
}
