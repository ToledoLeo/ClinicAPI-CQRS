using ClinicSystem.Domain.Enums;

namespace ClinicSystem.Domain.Entities;

public class Patient(string name, string phone, Gender gender, string email) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Phone { get; private set; } = phone;
    public Gender Gender { get; private set; } = gender;
    public string Email { get; private set; } = email;
    public IEnumerable<Service>? Services { get; set; }


    public void Update(string name, string phone, Gender gender, string email)
    {
        Name = name;
        Phone = phone;
        Gender = gender;
        Email = email;
    }
}