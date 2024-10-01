namespace ClinicSystem.Application.Models.Triages.Requests;

public record UpdateTriageRequest(Guid SpecialityId, string Symptoms, string BloodPressure, decimal Weight, decimal Height);