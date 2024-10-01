namespace ClinicSystem.Application.Constants.Errors;

public static class TriageErrors
{
    public static string IdNotFound(Guid id) 
        => $"Triagem com o id {id} não encontrada.";
}
