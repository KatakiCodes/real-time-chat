using realtime_chat_api.Enums;

namespace realtime_chat_api.DTOs.Responses;

public record class ResponseModel<T> where T : class
{
    public bool Success { get { return !Errors.Any(); } }
    public T? Data { get; init; }
    public EResultStatus Status { get; init; }
    public IEnumerable<string> Errors { get; init; } = [];

public ResponseModel<T> OK(T data) => new() { Data = data, Status = EResultStatus.OK, Errors = Array.Empty<string>() };
    public ResponseModel<T> CREATED(T data) => new() { Data = data, Status = EResultStatus.CREATED, Errors = Array.Empty<string>() };
    public ResponseModel<T> NOTFOUND(IEnumerable<string> errors) => new() { Status = EResultStatus.NOTFOUND, Errors = errors ?? [] };
    public ResponseModel<T> BADREQUEST(IEnumerable<string> errors) => new() { Status = EResultStatus.BADREQUEST, Errors = errors ?? [] };
    public ResponseModel<T> UNAUTHORIZED(IEnumerable<string> errors) => new() { Status = EResultStatus.UNAUTHORIZED, Errors = errors ?? [] };
    public ResponseModel<T> INTERNALSERVERERROR(IEnumerable<string> errors) => new() { Status = EResultStatus.INTERNALSERVERERROR, Errors = errors ?? [] };
   
}
