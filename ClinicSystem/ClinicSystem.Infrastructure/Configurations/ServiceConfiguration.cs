using ClinicSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSystem.Infrastructure.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.Property(s => s.SequentialNumber)
               .HasDefaultValueSql("NEXT VALUE FOR dbo.NumberSequence");

        builder.HasOne(s => s.Patient)
               .WithMany(p => p.Services)
               .HasForeignKey(s => s.PatientId);
    }
}