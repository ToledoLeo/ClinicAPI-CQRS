using ClinicSystem.Application.Models.Patients.Responses;
using ClinicSystem.Application.Models.Triages.Responses;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Enums;

namespace ClinicSystem.Application.Models.Services.Responses;

public class ServiceResponse(Guid Id, Guid patientId, int sequentialNumber, DateTime arrivalDate, Status status, Patient? patient, Triage? triage)
{
    public Guid Id { get; init; } = Id;
    public Guid PatientId { get; init; } = patientId;
    public int SequentialNumber { get; init; } = sequentialNumber;
    public DateTime ArrivalDate { get; init; } = arrivalDate;
    public Status Status { get; init; } = status;
    public PatientResponse? Patient { get; init; } = patient;
    public TriageResponse? Triage { get; init; } = triage;

    public static implicit operator ServiceResponse?(Service? service)
    {
        if (service == null)
            return null;

        return new(service.Id, service.PatientId, service.SequentialNumber, service.ArrivalDate, service.Status, service.Patient, service.Triage);
    }
}