using HealthApp.Application.Common;
using MediatR;

namespace HealthApp.Application.Abstractions.Commands;

public interface ICommand : IRequest<Result>, IBaseCommand { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand { }

public interface IBaseCommand { }
