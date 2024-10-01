namespace ClinicSystem.Application.Models.Triages.Requests;

public record CreateTriageRequest(Guid ServiceId, Guid SpecialityId, string Symptoms, string BloodPressure, decimal Weight, decimal Height);