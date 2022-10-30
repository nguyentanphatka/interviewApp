using System;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Core
{
    public static class InitServices
    {
        public static IServiceCollection AddServicesHandler(this IServiceCollection services)
        {
            //services.AddScoped<ISqlConnectHandler, SqlConnectHandler>();
            //services.AddScoped<IStudentService, StudentService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
             return services;
        }
    }
}
