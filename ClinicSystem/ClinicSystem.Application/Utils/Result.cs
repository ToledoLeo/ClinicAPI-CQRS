namespace ClinicSystem.Application.Utils;

public record Result<T>(T? Data, bool IsSuccess, string? Message = null)
{
    public bool IsSuccess { get; } = IsSuccess;

    public bool IsFailure => !IsSuccess;

    public string? Message { get; } = Message;

    public static Result<T> Success(T data) => new(data, true);

    public static Result<T> Failure(string message) => new(default, false, message);
}