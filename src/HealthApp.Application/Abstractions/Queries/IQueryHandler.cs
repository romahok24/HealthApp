﻿using HealthApp.Domain.Abstractions;
using MediatR;

namespace HealthApp.Application.Abstractions.Queries;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
