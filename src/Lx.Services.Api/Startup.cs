using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Lx.IdentityServer.Context;
using Lx.IdentityServer.Models;
using Lx.Services.Api.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Lx.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddAspNetIdentity<ApplicationUser>()
                 // 添加配置数据（客户端 和 资源）
                 .AddConfigurationStore(options =>
                 {
                     options.ConfigureDbContext = b =>
                         b.UseOracle(connectionString,
                             sql => sql.MigrationsAssembly(migrationsAssembly));
                 })
                 // 添加操作数据 (codes, tokens, consents)
                 .AddOperationalStore(options =>
                 {
                     options.ConfigureDbContext = b =>
                         b.UseOracle(connectionString,
                             sql => sql.MigrationsAssembly(migrationsAssembly));
                     // 自动清理 token ，可选
                     options.EnableTokenCleanup = true;
                 });
            // 数据库配置系统应用用户数据上下文
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseOracle(connectionString));
            // 启用 Identity 服务 添加指定的用户和角色类型的默认标识系统配置
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            //    .AddTestUsers(IdentityServer4Config.Users().ToList())
            //    .AddInMemoryApiScopes(IdentityServer4Config.GetApiScopes())
            //    .AddInMemoryApiResources(IdentityServer4Config.GetApiResources())
            //    .AddInMemoryClients(IdentityServer4Config.GetClients());

            //builder.AddDeveloperSigningCredential();

            services.AddAuthentication();   //配置认证服务
            // Automapper 注入
            services.AddAutoMapperSetup();

            // Adding MediatR for Domain Events
            // 领域命令、领域事件等注入
            // 引用包 MediatR.Extensions.Microsoft.DependencyInjection
            services.AddMediatR(typeof(Startup));

            // .NET Core 原生依赖注入
            // 单写一层用来添加依赖项，从展示层 Presentation 中隔离
            NativeInjectorBootStrapper.RegisterServices(services);

            // 配置跨域处理，允许所有来源
            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:7805").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // 允许所有跨域，cors是在ConfigureServices方法中配置的跨域策略名称
            app.UseCors("cors");

            app.UseIdentityServer();

            app.UseAuthentication();    //认证
            app.UseAuthorization();     //授权

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
