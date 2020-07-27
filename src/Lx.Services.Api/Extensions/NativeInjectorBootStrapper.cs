﻿using Lx.Application.Interfaces;
using Lx.Application.Services;
using Lx.Domain.CommandHandlers;
using Lx.Domain.Commands.Student;
using Lx.Domain.Core.Bus;
using Lx.Domain.Core.Notifications;
using Lx.Domain.EventHandlers;
using Lx.Domain.Events.Student;
using Lx.Domain.Interfaces;
using Lx.Infrastruct.Data.Bus;
using Lx.Infrastruct.Data.Context;
using Lx.Infrastruct.Data.Repository;
using Lx.Infrastruct.Data.UoW;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
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
            services.AddScoped<ILoginAppService, LoginAppService>();

            // 命令总线Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // 领域通知
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            // 领域事件
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();

            // 领域层 - 领域命令
            // 将命令模型和命令处理程序匹配
            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>, StudentCommandHandler>();

            // 领域层 - Memory
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });

            //注入 基础设施层 - 数据层
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<LxContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}