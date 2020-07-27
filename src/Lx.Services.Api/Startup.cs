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
                 // ����������ݣ��ͻ��� �� ��Դ��
                 .AddConfigurationStore(options =>
                 {
                     options.ConfigureDbContext = b =>
                         b.UseOracle(connectionString,
                             sql => sql.MigrationsAssembly(migrationsAssembly));
                 })
                 // ��Ӳ������� (codes, tokens, consents)
                 .AddOperationalStore(options =>
                 {
                     options.ConfigureDbContext = b =>
                         b.UseOracle(connectionString,
                             sql => sql.MigrationsAssembly(migrationsAssembly));
                     // �Զ����� token ����ѡ
                     options.EnableTokenCleanup = true;
                 });
            // ���ݿ�����ϵͳӦ���û�����������
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseOracle(connectionString));
            // ���� Identity ���� ���ָ�����û��ͽ�ɫ���͵�Ĭ�ϱ�ʶϵͳ����
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            //    .AddTestUsers(IdentityServer4Config.Users().ToList())
            //    .AddInMemoryApiScopes(IdentityServer4Config.GetApiScopes())
            //    .AddInMemoryApiResources(IdentityServer4Config.GetApiResources())
            //    .AddInMemoryClients(IdentityServer4Config.GetClients());

            //builder.AddDeveloperSigningCredential();

            services.AddAuthentication();   //������֤����
            // Automapper ע��
            services.AddAutoMapperSetup();

            // Adding MediatR for Domain Events
            // ������������¼���ע��
            // ���ð� MediatR.Extensions.Microsoft.DependencyInjection
            services.AddMediatR(typeof(Startup));

            // .NET Core ԭ������ע��
            // ��дһ����������������չʾ�� Presentation �и���
            NativeInjectorBootStrapper.RegisterServices(services);

            // ���ÿ���������������Դ
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

            // �������п���cors����ConfigureServices���������õĿ����������
            app.UseCors("cors");

            app.UseIdentityServer();

            app.UseAuthentication();    //��֤
            app.UseAuthorization();     //��Ȩ

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
