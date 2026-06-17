namespace SmartKart.Identity.API.Contracts;

public sealed record ErrorResponse(
bool Success,
string Message,
string TraceId,
string? ErrorCode = null);
