using Lx.Domain.Models.SystemManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Infrastruct.Data.Mappings.SystemManager
{
    public class LoginRecordMap : IEntityTypeConfiguration<LoginRecord>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<LoginRecord> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Ip)
                .HasColumnType("varchar(200)")
                .HasColumnName("IP")
                .HasMaxLength(200);

            builder.Property(c => c.Area)
                .HasColumnType("varchar(200)")
                .HasColumnName("AREA")
                .HasMaxLength(200);

            builder.Property(c => c.Brower)
                .HasColumnType("varchar(200)")
                .HasColumnName("BROWER")
                .HasMaxLength(200);

            builder.Property(c => c.Os)
                .HasColumnType("varchar(200)")
                .HasColumnName("OS")
                .HasMaxLength(200);

            builder.Property(c => c.MerchantId)
                .HasColumnName("MERCHANTID");

            builder.Property(c => c.CreateTime)
                .HasColumnType("date")
                .HasColumnName("CREATETIME")
                .IsRequired();

            builder.Property(c => c.LastUpdateTime)
                .HasColumnType("varchar(200)")
                .HasColumnName("LASTUPDATETIME");

            //设置实体的属性为EF Core实体的Key属性
            builder.HasKey(e => e.Id)
                .HasName("IDX_LOGIN_RECORD_ID");

            builder.HasIndex(t => t.CreateTime)
                .HasName("IDX_LOGIN_RECORD_CREATETIME");

            builder.HasIndex(t => t.MerchantId)
                .HasName("IDX_LOGIN_RECORD_MERCHANTID");

            builder.HasOne(p => p.MerchantsAccount)
                .WithMany(b => b.LoginRecord)
                .HasForeignKey(p => p.MerchantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MERCHANTID");

        }
    }
}
