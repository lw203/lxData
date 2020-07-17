using Lx.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Infrastruct.Data.Mappings
{
    /// <summary>
    /// 学生map类
    /// </summary>
    public class StudentMap: IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasColumnName("EMAIL")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasColumnType("varchar(100)")
                .HasColumnName("PHONE")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .HasColumnName("BIRTHDATE")
                .IsRequired(); 

            builder.OwnsOne(
                o => o.Address,
                sa =>
                {
                    sa.Property(p => p.County).HasColumnName("ADDRESS_COUNTY");
                    sa.Property(p => p.Province).HasColumnName("ADDRESS_PROVINCE");
                    sa.Property(p => p.City).HasColumnName("ADDRESS_CITY");
                    sa.Property(p => p.Street).HasColumnName("ADDRESS_STREET");

                }
            );

            //处理值对象配置，否则会被视为实体
            builder.OwnsOne(p => p.Address);
        }
    }
}
