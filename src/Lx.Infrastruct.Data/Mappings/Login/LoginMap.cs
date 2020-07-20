using Lx.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Infrastruct.Data.Mappings
{
    public class LoginMap : IEntityTypeConfiguration<Login>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.LoginName)
                .HasColumnType("varchar(100)")
                .HasColumnName("LOGINNAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.PassWord)
                .HasColumnType("varchar(32)")
                .HasColumnName("PASSWORD")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(c => c.NiceName)
                .HasColumnType("varchar(100)")
                .HasColumnName("NICENAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Lock)
                .HasColumnName("LOCK")
                .IsRequired();

            builder.Property(c => c.CreateTime)
                .HasColumnName("CREATETIME")
                .IsRequired();
        }
    }
}
