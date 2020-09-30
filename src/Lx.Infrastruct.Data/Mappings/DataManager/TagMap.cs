using Lx.Domain.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Infrastruct.Data.Mappings.DataManager
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.ParentId)
                .HasColumnName("PARENTID");

            builder.Property(c => c.CreateTime)
                .HasColumnType("date")
                .HasColumnName("CREATETIME")
                .IsRequired();

            builder.Property(c => c.CreateId)
                .HasColumnName("CREATEID");

            builder.Property(c => c.LastUpdateTime)
                .HasColumnType("varchar(100)")
                .HasColumnName("LASTUPDATETIME");

            builder.Property(c => c.UpdateId)
                .HasColumnName("UPDATEID");

            builder.HasIndex(t => t.ParentId)
                .HasName("IDX_PARENTID");
        }
    }
}
