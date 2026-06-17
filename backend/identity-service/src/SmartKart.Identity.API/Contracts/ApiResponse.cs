namespace SmartKart.Identity.API.Contracts;

public sealed record ApiResponse<T>(bool IsSuccess, string Message, T? Data, string? TraceId);
