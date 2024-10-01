namespace ClinicSystem.Application.Constants.Errors;

public static class ServiceErrors
{
    public static string TriageServiceNotFound 
        => "Não há pacientes em espera para a triagem.";

    public static string MedicalServiceNotFound
        => "Não há pacientes em espera para atendimento médico.";

    public static string MedicalStatusChangeError(Guid id)
        => $"Erro ao enviar atendimento id {id} para atendimento médico.";

    public static string CompleteServiceError(Guid id)
        => $"Erro ao completar atendimento id {id}.";

    public static string IdNotFound(Guid id)
    => $"Atendimento com o id {id} não encontrado.";
}
