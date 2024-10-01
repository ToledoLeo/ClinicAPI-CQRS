using ClinicSystem.Domain.Enums;

namespace ClinicSystem.Application.Models.Patients.Requests;

public record UpdatePatientRequest(string Name, string Phone, Gender Gender, string Email);