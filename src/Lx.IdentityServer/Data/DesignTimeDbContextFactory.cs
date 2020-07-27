using Lx.IdentityServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lx.IdentityServer.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        //ApplicationDbContext 代表的是你的创建失败的那个类型
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder();
            builder.UseOracle(config.GetConnectionString("DefaultConnection"), b => b.UseOracleSQLCompatibility("11"));
            return new ApplicationDbContext(builder.Options);
        }
    }
}
