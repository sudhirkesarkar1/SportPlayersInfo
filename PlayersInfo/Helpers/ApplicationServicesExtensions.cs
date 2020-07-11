using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PlayersInfo.EntityModelsData.Data;
using PlayersInfo.EntityModelsData.Models.Interfaces;
using PlayersInfo.Errors;

namespace PlayersInfo.Helpers
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.Configure<ApiBehaviorOptions>(options => 
                {
                    options.InvalidModelStateResponseFactory = actionContext => 
                    {
                        var errors = actionContext.ModelState
                                        .Where(e => e.Value.Errors.Count > 0)
                                        .SelectMany(x => x.Value.Errors)
                                        .Select(x => x.ErrorMessage).ToArray();
                        var errorResponse = new ApiValidationErrorResponse
                        {
                            Errors = errors
                        };
                        return new BadRequestObjectResult(errorResponse);
                    };
                });
            
            return services;
        }
    }
}