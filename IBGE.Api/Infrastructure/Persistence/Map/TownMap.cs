using System;
using IBGE.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGE.Api.Infrastructure.Persistence.Map
{
    public class TownMap : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Town");
            builder.HasKey(x => x.TownId).HasName("TownId");
            builder.Property(x => x.StateId).HasColumnName("StateId")
                                            .HasColumnType("tynint");

            builder.OwnsOne(x => x.Name, c =>
            {
                c.Property(p => p.Value).HasColumnName("Name")
                                          .HasColumnType("nvarchar(50)")
                                          .IsRequired();
            });

            builder.Ignore(x=> x.State);
        }
    }
}

