using Lx.Domain.Models.SystemManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Infrastruct.Data.Mappings.SystemManager
{
    public class MerchantsAccountMap : IEntityTypeConfiguration<MerchantsAccount>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<MerchantsAccount> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.NickName)
                .HasColumnType("varchar(100)")
                .HasColumnName("NICKNAME")
                .HasMaxLength(100)
                
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasColumnType("varchar(20)")
                .HasColumnName("PHONE")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasColumnName("EMAIL")
                .HasMaxLength(100);

            builder.Property(c => c.PassWord)
                .HasColumnType("varchar(100)")
                .HasColumnName("PASSWORD")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Avatar)
                .HasColumnType("varchar(200)")
                .HasColumnName("AVATAR")
                .HasMaxLength(200);

            builder.Property(c => c.CreateTime)
                .HasColumnType("date")
                .HasColumnName("CREATETIME")
                .IsRequired();
        }
    }
}
