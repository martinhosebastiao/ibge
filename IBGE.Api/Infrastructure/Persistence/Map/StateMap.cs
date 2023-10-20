using IBGE.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGE.Api.Infrastructure.Persistence.Map
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");
            builder.HasKey(x => x.StateId).HasName("StateId");
            builder.Property(x => x.StateId).HasColumnType("tynint");
           
            builder.Property(x => x.Acronym).HasColumnName("Acronym")
                                            .HasColumnType("nvarchar(4)")
                                            .IsRequired();

            builder.OwnsOne(x => x.Name, c =>
            {
                c.Property(p => p.Value).HasColumnName("Name")
                                        .HasColumnType("nvarchar(30)")
                                        .IsRequired();
            });

            builder.Ignore(x=> x.Towns);
        }
    }
}

