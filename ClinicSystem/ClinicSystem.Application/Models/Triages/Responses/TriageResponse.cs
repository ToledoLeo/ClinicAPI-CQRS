using ClinicSystem.Domain.Entities;

namespace ClinicSystem.Application.Models.Triages.Responses;

public class TriageResponse(Guid Id, Guid serviceId, Guid specialityId, string symptoms, string bloodPressure, decimal weight, decimal height)
{
    public Guid Id { get; init; } = Id;
    public Guid ServiceId { get; init; } = serviceId;
    public Guid SpecialityId { get; init; } = specialityId;
    public string Symptoms { get; init; } = symptoms;
    public string BloodPressure { get; init; } = bloodPressure;
    public decimal Weight { get; init; } = weight;
    public decimal Height { get; init; } = height;

    public static implicit operator TriageResponse?(Triage? triage)
    {
        if (triage == null)
            return null;

        return new(triage.Id, triage.ServiceId, triage.SpecialityId, triage.Symptoms, triage.BloodPressure, triage.Weight, triage.Height);
    }
}