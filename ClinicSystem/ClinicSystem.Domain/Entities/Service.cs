using ClinicSystem.Domain.Enums;

namespace ClinicSystem.Domain.Entities;

public class Service(Guid patientId) : BaseEntity
{
    public Guid PatientId { get; private set; } = patientId;
    public int SequentialNumber { get; private set; }
    public DateTime ArrivalDate { get; private set; } = DateTime.UtcNow;
    public Status Status { get; private set; } = Status.Triage;
    public Patient? Patient { get; set; }
    public Triage? Triage { get; set; }
}