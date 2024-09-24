using HealthApp.Domain.Abstractions;
using MediatR;

namespace HealthApp.Application.Abstractions.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }