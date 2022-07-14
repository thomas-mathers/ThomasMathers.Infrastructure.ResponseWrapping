﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using ThomasMathers.Common.ResponseWrapping.Models;

namespace ThomasMathers.Common.ResponseWrapping.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddResponseWrapping(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = new List<ApiValidationError>();

                    foreach (var property in actionContext.ModelState)
                    {
                        foreach (var error in property.Value.Errors)
                        {
                            errors.Add(new ApiValidationError
                            {
                                Property = property.Key,
                                Description = error.ErrorMessage
                            });
                        }
                    }

                    return new BadRequestObjectResult(errors);
                };
            });

            services.AddSingleton<IActionResultExecutor<ObjectResult>, ApiResultExecutor>();
        }
    }
}
