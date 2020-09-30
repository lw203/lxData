using Lx.Application.Interfaces;
using Lx.Application.Interfaces.DataManager;
using Lx.Application.Interfaces.SystemManager;
using Lx.Application.Services;
using Lx.Application.Services.DataManager;
using Lx.Domain.CommandHandlers;
using Lx.Domain.CommandHandlers.SystemManager;
using Lx.Domain.Commands.SystemManager;
using Lx.Domain.Core.Bus;
using Lx.Domain.Core.Notifications;
using Lx.Domain.EventHandlers;
using Lx.Domain.EventHandlers.SystemManager;
using Lx.Domain.Events.SystemManager;
using Lx.Domain.Interfaces;
using Lx.Domain.Interfaces.DataManager;
using Lx.Domain.Interfaces.SystemManager;
using Lx.Infrastruct.Data.Bus;
using Lx.Infrastruct.Data.Context;
using Lx.Infrastruct.Data.Repository;
using Lx.Infrastruct.Data.Repository.DataManager;
using Lx.Infrastruct.Data.Repository.SystemManager;
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
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IUserAccountAppService, UserAccountAppService>();
            services.AddScoped<ILoginRecordAppService, LoginRecordAppService>();
            services.AddScoped<IPeopleAppService, PeopleAppService>();
            services.AddScoped<ITagAppService, TagAppService>();
            services.AddScoped<IWordCloudAppService, WordCloudAppService>();

            // 命令总线Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // 领域通知
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            // 领域事件
            services.AddScoped<INotificationHandler<AddUserAccoutEvent>, UserAccountEventHandler>();
            services.AddScoped<INotificationHandler<UpdateUserAccoutEvent>, UserAccountEventHandler>();

            // 领域层 - 领域命令
            // 将命令模型和命令处理程序匹配
            services.AddScoped<IRequestHandler<AddUserAccountCommand, Unit>, UserAccountCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserAccountCommand, Unit>, UserAccountCommandHandler>();

            // 领域层 - Memory
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });

            //注入 基础设施层 - 数据层
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<ILoginRecordRepository, LoginRecordRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<LxContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
