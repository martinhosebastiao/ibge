using System;
using IBGE.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGE.Api.Infrastructure.Persistence.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.UserId).HasName("UserId");
            builder.Property(x => x.UserId).ValueGeneratedOnAdd()
                                           .HasColumnType("smallint");
            builder.Property(x => x.Role).HasColumnName("Role")
                                          .HasColumnType("nvarchar(10)");
            builder.OwnsOne(x => x.Email, c =>
            {
                c.Property(p => p.Address).HasColumnName("Email")
                                          .HasColumnType("nvarchar(50)")
                                          .IsRequired();
                c.Ignore(x => x.HasValid);
                c.Ignore(x => x.Notifications);
            });

            builder.OwnsOne(x => x.Password, c =>
            {
                c.Property(p => p.Hash).HasColumnName("Password")
                                       .HasColumnType("nvarchar(50)")
                                       .IsRequired();
                c.Ignore(x => x.HasValid);
                c.Ignore(x => x.Notifications);
            });

            builder.Ignore(x => x.HasValid);
            builder.Ignore(x => x.Notifications);
        }
    }
}

