using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartTaskHub.Application.Common.Behaviors;

namespace SmartTaskHub.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            // Register MediatR
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                // REGISTER THE PIPELINE BEHAVIOR
                cfg.AddBehavior(typeof(IPipelineBehavior<,>),
                    typeof(ValidationBehavior<,>));
            });

            // Register Validators (Scans the assembly for AbstractValidator classes)
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
