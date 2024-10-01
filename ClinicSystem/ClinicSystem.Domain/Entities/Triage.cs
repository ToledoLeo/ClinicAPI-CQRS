namespace ClinicSystem.Domain.Entities;

public class Triage(Guid serviceId, Guid specialityId, string symptoms, string bloodPressure, decimal weight, decimal height) : BaseEntity
{
    public Guid ServiceId { get; private set; } = serviceId;
    public Guid SpecialityId { get; private set; } = specialityId;
    public string Symptoms { get; private set; } = symptoms;
    public string BloodPressure { get; private set; } = bloodPressure;
    public decimal Weight { get; private set; } = weight;
    public decimal Height { get; private set; } = height;
    public Service? Service { get; set; }

    public void Update(Guid specialityId, string symptoms, string bloodPressure, decimal weight, decimal height)
    {
        SpecialityId = specialityId;
        Symptoms = symptoms;
        BloodPressure = bloodPressure;
        Weight = weight;
        Height = height;
    }
}