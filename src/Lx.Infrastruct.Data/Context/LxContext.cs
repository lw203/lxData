using Lx.Domain.Models;
using Lx.Domain.Models.SystemManager;
using Lx.Infrastruct.Data.EFCoreLog;
using Lx.Infrastruct.Data.Mappings;
using Lx.Infrastruct.Data.Mappings.SystemManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lx.Infrastruct.Data.Context
{
    public class LxContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level)  => category == DbLoggerCategory.Database.Command.Name&& level == LogLevel.Information, true)
        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MerchantsAccountMap());
            modelBuilder.ApplyConfiguration(new LoginRecordMap());

            //modelBuilder.HasDefaultSchema("NETCORE");
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //从appsetting.json中获取配置信息
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            ILoggerProvider loggerProvider = new EFLoggerProvider();
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(loggerProvider);


            //定义要使用的数据库
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .UseOracle(config.GetConnectionString("DefaultConnection"), b => b.UseOracleSQLCompatibility("11"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //optionsBuilder.UseOracle(config.GetConnectionString("DefaultConnection"));
        }
    }
}
