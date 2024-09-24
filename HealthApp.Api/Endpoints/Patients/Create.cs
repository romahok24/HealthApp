﻿using HealthApp.Application.Patients.Create;
using HealthApp.Web.Api.Extensions;
using HealthApp.Web.Api.Infrastructure;
using MediatR;

namespace HealthApp.Web.Api.Endpoints.Patients;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("patients", async (CreatePatientCommand command, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(command, cancellationToken);
                
            return result.Match(CustomResults.Ok, CustomResults.Problem);
        });
    }
}