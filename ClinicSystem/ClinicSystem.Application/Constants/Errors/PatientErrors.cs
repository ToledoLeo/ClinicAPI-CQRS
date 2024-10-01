namespace ClinicSystem.Application.Constants.Errors;

public static class PatientErrors
{
    public static string IdNotFound(Guid id) 
        => $"Paciente com o id {id} não encontrado.";

    public static string EmailNotFound(string email) 
        => $"Paciente com o email {email} não encontrado.";
}
