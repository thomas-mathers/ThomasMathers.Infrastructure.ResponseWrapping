using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThomasMathers.Infrastructure.ResponseWrapping.Models;

namespace ThomasMathers.Infrastructure.ResponseWrapping
{
    internal class ApiResultExecutor : ObjectResultExecutor
    {
        public ApiResultExecutor(OutputFormatterSelector formatterSelector, IHttpResponseStreamWriterFactory writerFactory, ILoggerFactory loggerFactory, IOptions<MvcOptions> mvcOptions) : base(formatterSelector, writerFactory, loggerFactory, mvcOptions)
        {
        }

        public override Task ExecuteAsync(ActionContext context, ObjectResult result)
        {
            var innerValue = result.Value;

            if (innerValue is not ApiResult)
            {
                var isSuccess = result.StatusCode >= 200 && result.StatusCode < 300;

                if (isSuccess)
                {
                    result.Value = new ApiResult { Value = innerValue };
                }
                else if (innerValue is string errorMessage)
                {
                    result.Value = new ApiResult { ErrorMessage = errorMessage };
                }
                else
                {
                    result.Value = new ApiResult { Error = innerValue };  
                }
            }

            return base.ExecuteAsync(context, result);
        }
    }
}
