using Lx.Domain.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Infrastruct.Data.Mappings.DataManager
{
    public class PeopleDetailMap : IEntityTypeConfiguration<PeopleDetail>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PeopleDetail> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Title)
                .HasColumnType("varchar(200)")
                .HasColumnName("TITLE")
                .HasMaxLength(200);

            builder.Property(c => c.SubTitle)
                .HasColumnType("varchar(200)")
                .HasColumnName("SUBTITLE")
                .HasMaxLength(200);

            builder.Property(c => c.Content)
                .HasColumnType("varchar(4000)")
                .HasColumnName("CONTENT")
                .HasMaxLength(4000);

            builder.Property(c => c.CheckId)
                .HasColumnName("CHECKID");

            builder.Property(c => c.CheckTime)
                .HasColumnType("date")
                .HasColumnName("CHECKTIME");

            builder.Property(c => c.PeopleId)
                .HasColumnName("PEOPLEID");

            builder.Property(c => c.CreateTime)
                .HasColumnType("date")
                .HasColumnName("CREATETIME")
                .IsRequired();

            builder.Property(c => c.CreateId)
                .HasColumnName("CREATEID");

            builder.Property(c => c.LastUpdateTime)
                .HasColumnType("varchar(200)")
                .HasColumnName("LASTUPDATETIME");

            builder.Property(c => c.UpdateId)
                .HasColumnName("UPDATEID");

            //设置实体的属性为EF Core实体的Key属性
            builder.HasKey(e => e.Id)
                .HasName("IDX_PEOPLE_DETAIL_ID");

            builder.HasIndex(t => t.CreateTime)
                .HasName("IDX_PEOPLE_DETAIL_CREATETIME");

            builder.HasIndex(t => t.PeopleId)
                .HasName("IDX_PEOPLE_DETAIL_PEOPLEID");

            builder.HasOne(p => p.People)
                .WithMany(b => b.PeopleDetails)
                .HasForeignKey(p => p.PeopleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PEOPLEID");

        }
    }
}
