using Lx.Application.Interfaces;
using Lx.Application.Services;
using Lx.Domain.Interfaces;
using Lx.Infrastruct.Data.Context;
using Lx.Infrastruct.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lx.Services.Api.Extensions
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //注入 应用层Application
            services.AddScoped<IStudentAppService, StudentAppService>();

            //注入 基础设施层 - 数据层
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudyContext>();
        }
    }
}
