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

            builder.OwnsOne(x => x.Email, c =>
            {
                c.Property(p => p.Address).HasColumnName("Email")
                                          .HasColumnType("nvarchar(50)")
                                          .IsRequired();
            });

            builder.OwnsOne(x => x.Password, c =>
            {
                c.Property(p => p.Hash).HasColumnName("Password")
                                       .HasColumnType("nvarchar(5s0)")
                                       .IsRequired();
            });
        }
    }
}

