using Lx.Domain.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Infrastruct.Data.Mappings.DataManager
{
    public class PoetryMap : IEntityTypeConfiguration<Poetry>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Poetry> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Title)
                .HasColumnType("varchar(1000)")
                .HasColumnName("TITLE")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(c => c.PeopleId)
                .HasColumnName("PEOPLEID");

            builder.Property(c => c.PeopleName)
                .HasColumnType("varchar(200)")
                .HasColumnName("PEOPLENAME")
                .HasMaxLength(200);

            builder.Property(c => c.Status)
                .HasColumnType("varchar(20)")
                .HasColumnName("STATUS")
                .HasMaxLength(20);

            builder.Property(c => c.CheckId)
                .HasColumnName("CHECKID");

            builder.Property(c => c.CheckTime)
                .HasColumnType("varchar(100)")
                .HasColumnName("CHECKTIME");

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

            builder.HasIndex(t => t.PeopleName)
                .HasName("IDX_PEOPLE_NAME");
            builder.HasIndex(t => t.PeopleId)
                .HasName("IDX_PEOPLE_ID");
            builder.HasIndex(t => t.CreateTime)
                .HasName("IDX_POETRY_CREATETIME");

            //设置Person实体和Book实体之间的一对多关系，尽管我们并没有在数据库中建立Person表和Book表之间的一对多外键关系，但是我们可以用EF Core的Fluent API在实体层面设置外键关系
            builder.HasMany(p => p.PoetryDetails)//设置Person实体通过属性Book可以找到多个Book实体，表示Person表是一对多关系中的主表
            .WithOne(b => b.Poetry)//设置Book实体通过属性Person可以找到一个Person实体，表示Book表是一对多关系中的从表
            .HasPrincipalKey(p => p.Id)//设置Person表的PersonCode列为一对多关系中的主表键
            .HasForeignKey(b => b.PoetryId)//设置Book表的PersonCode列为一对多关系中的从表外键
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_POETRYDETAIL_POETRYID");//设置一对多关系的级联删除效果为DeleteBehavior.ClientSetNull
        }
    }
}
