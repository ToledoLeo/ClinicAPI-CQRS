using ClinicSystem.Domain.Enums;

namespace ClinicSystem.Application.Models.Patients.Requests;

public record CreatePatientRequest(string Name, string Phone, Gender Gender, string Email);