using HealthApp.Application.Common;
using MediatR;

namespace HealthApp.Application.Abstractions.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }