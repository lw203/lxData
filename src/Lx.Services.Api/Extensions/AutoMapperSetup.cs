using Lx.Application.AutoMapper;
using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Lx.Services.Api.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            //添加服务
            services.AddAutoMapper(typeof(AutoMapperConfig));
            //启动配置
            AutoMapperConfig.RegisterMappings();
        }
    }
}
