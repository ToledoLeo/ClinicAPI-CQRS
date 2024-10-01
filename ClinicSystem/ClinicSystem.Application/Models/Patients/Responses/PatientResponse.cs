using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Enums;

namespace ClinicSystem.Application.Models.Patients.Responses;

public class PatientResponse(Guid id, string name, string phone, Gender gender, string email)
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Phone { get; init; } = phone;
    public Gender Gender { get; init; } = gender;
    public string Email { get; init; } = email;

    public static implicit operator PatientResponse?(Patient? patient)
    {
        if (patient == null)
            return null;

        return new(patient.Id, patient.Name, patient.Phone, patient.Gender, patient.Email);
    }
}