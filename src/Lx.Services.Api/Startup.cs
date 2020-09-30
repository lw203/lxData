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

            services.AddAuthentication();   //������֤����

            //ע�����
            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication(x =>
            {
                x.Authority = "https://localhost:5001";//��Ȩ�����ַ
                x.RequireHttpsMetadata = false;
                x.ApiName = "api1";//��Ȩ��Χ
            });

            // Automapper ע��
            services.AddAutoMapperSetup();

            // Adding MediatR for Domain Events
            // ������������¼���ע��
            // ���ð� MediatR.Extensions.Microsoft.DependencyInjection
            services.AddMediatR(typeof(Startup));

            // .NET Core ԭ������ע��
            // ��дһ����������������չʾ�� Presentation �и���
            NativeInjectorBootStrapper.RegisterServices(services);

            services.AddControllers()
                .AddJsonOptions(configure => {
                    configure.JsonSerializerOptions.Converters.Add(new DatetimeJsonConverter());
                });

            // ���ÿ���������������Դ
            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8002").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
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

            //app.UseIdentityServer();

            app.UseAuthentication();    //��֤
            app.UseAuthorization();     //��Ȩ

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
