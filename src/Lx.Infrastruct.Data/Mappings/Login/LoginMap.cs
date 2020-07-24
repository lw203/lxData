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
                .HasColumnName("I_ID");

            builder.Property(c => c.LoginName)
                .HasColumnType("varchar(100)")
                .HasColumnName("C_LOGINNAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.PassWord)
                .HasColumnType("varchar(100)")
                .HasColumnName("C_PASSWORD")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(c => c.NiceName)
                .HasColumnType("varchar(100)")
                .HasColumnName("C_NICENAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Lock)
                .HasColumnName("i_LOCK")
                .IsRequired();

            builder.Property(c => c.CreateTime)
                .HasColumnName("D_CREATETIME")
                .IsRequired();
        }
    }
}
