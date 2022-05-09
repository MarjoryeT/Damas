using Jogar.Damas.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogar.Damas.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USER");

            builder.HasKey(user => user.UserId);

            builder.Property(user => user.UserId).HasColumnName("USER_ID");

            builder.Property(user => user.UserName)
                .HasColumnName("USER_NAME")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(user => user.Password)
                .HasColumnName("PASSWORD")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(user => user.Email)
                 .HasColumnName("EMAIL")
                 .HasMaxLength(50)
                 .HasColumnType("VARCHAR")
                 .IsRequired();

            builder.Property(user => user.Phone)
                .HasColumnName("PHONE")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(user => user.StartDate)
                .HasColumnName("START_DATE")
                .IsRequired();
        }
    }
}
