using Lx.Domain.Models.DataManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Infrastruct.Data.Mappings.DataManager
{
    public class PeopleMap : IEntityTypeConfiguration<People>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.PeopleName)
                .HasColumnType("varchar(100)")
                .HasColumnName("PEOPLENAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Dynasty)
                .HasColumnType("varchar(50)")
                .HasColumnName("DYNASTY")
                .HasMaxLength(50);

            builder.Property(c => c.Sort)
                .HasColumnType("varchar(50)")
                .HasColumnName("SORT")
                .HasMaxLength(50);

            builder.Property(c => c.Explain)
                .HasColumnType("varchar(4000)")
                .HasColumnName("EXPLAIN")
                .HasMaxLength(100);

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
            builder.HasIndex(t => t.Dynasty)
                .HasName("IDX_PEOPLE_DYNASTY");
            builder.HasIndex(t => t.CreateTime)
                .HasName("IDX_PEOPLE_CREATETIME");

            //设置Person实体和Book实体之间的一对多关系，尽管我们并没有在数据库中建立Person表和Book表之间的一对多外键关系，但是我们可以用EF Core的Fluent API在实体层面设置外键关系
            builder.HasMany(p => p.PeopleDetails)//设置Person实体通过属性Book可以找到多个Book实体，表示Person表是一对多关系中的主表
            .WithOne(b => b.People)//设置Book实体通过属性Person可以找到一个Person实体，表示Book表是一对多关系中的从表
            .HasPrincipalKey(p => p.Id)//设置Person表的PersonCode列为一对多关系中的主表键
            .HasForeignKey(b => b.PeopleId)//设置Book表的PersonCode列为一对多关系中的从表外键
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PEOPLEDETAIL_PEOPLEID");//设置一对多关系的级联删除效果为DeleteBehavior.ClientSetNull
        }
    }
}
