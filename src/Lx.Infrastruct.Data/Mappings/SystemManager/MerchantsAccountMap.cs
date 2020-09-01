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
                .HasMaxLength(32);

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasColumnName("EMAIL")
                .HasMaxLength(100);

            builder.Property(c => c.PassWord)
                .HasColumnType("varchar(100)")
                .HasColumnName("PASSWORD")
                .HasMaxLength(100);

            builder.Property(c => c.Avatar)
                .HasColumnType("varchar(200)")
                .HasColumnName("AVATAR")
                .HasMaxLength(200);

            builder.Property(c => c.CreateTime)
                .HasColumnType("date")
                .HasColumnName("CREATETIME")
                .IsRequired();

            builder.Property(c => c.LastUpdateTime)
                .HasColumnType("varchar(200)")
                .HasColumnName("LASTUPDATETIME");

            builder.HasIndex(t => t.NickName)
                .HasName("IDX_MERCHANT_ACCOUNT_NICKNAME");
            builder.HasIndex(t => t.Phone)
                .HasName("IDX_MERCHANT_ACCOUNT_PHONE");
            builder.HasIndex(t => t.CreateTime)
                .HasName("IDX_MERCHANT_ACCOUNT_CTIME");

            //设置Person实体和Book实体之间的一对多关系，尽管我们并没有在数据库中建立Person表和Book表之间的一对多外键关系，但是我们可以用EF Core的Fluent API在实体层面设置外键关系
            builder.HasMany(p => p.LoginRecord)//设置Person实体通过属性Book可以找到多个Book实体，表示Person表是一对多关系中的主表
            .WithOne(b => b.MerchantsAccount)//设置Book实体通过属性Person可以找到一个Person实体，表示Book表是一对多关系中的从表
            .HasPrincipalKey(p => p.Id)//设置Person表的PersonCode列为一对多关系中的主表键
            .HasForeignKey(b => b.MerchantId)//设置Book表的PersonCode列为一对多关系中的从表外键
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_LOGIN_RECORD_MERCHANTID");//设置一对多关系的级联删除效果为DeleteBehavior.ClientSetNull
        }
    }
}
