using ClinicSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSystem.Infrastructure.Configurations;

public class TriageConfiguration : IEntityTypeConfiguration<Triage>
{
    public void Configure(EntityTypeBuilder<Triage> builder)
    {
        builder.Property(t => t.Height).HasPrecision(3, 2);
        builder.Property(t => t.Weight).HasPrecision(5, 2);
        builder.Property(t => t.Symptoms).HasMaxLength(1000);
        builder.Property(t => t.BloodPressure).HasMaxLength(10);

        builder.HasOne(t => t.Service)
               .WithOne(s => s.Triage)
               .HasForeignKey<Triage>(t => t.ServiceId);
    }
}