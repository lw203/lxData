using Lx.Domain.Models;
using Lx.Infrastruct.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lx.Infrastruct.Data.Context
{
    /// <summary>
    /// 定义核心子领域
    /// </summary>
    public class StudyContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
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
            //定义要使用的数据库
            
            optionsBuilder.UseOracle(config.GetConnectionString("DefaultConnection"));
        }
    }
}
