using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Enums;
using MediatR;

namespace ClinicSystem.Application.CQRS.Patients.Commands;

public record RegisterPatient(string Name, string Phone, Gender Gender, string Email) : IRequest<Result<Guid>>;