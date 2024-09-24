using HealthApp.Application.Patients.Delete;
using HealthApp.Web.Api.Extensions;
using HealthApp.Web.Api.Infrastructure;
using MediatR;

namespace HealthApp.Web.Api.Endpoints.Patients;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("patients/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new DeletePatientCommand(id);
            var result = await sender.Send(command, cancellationToken);

            return result.Match(CustomResults.SimpleOk, CustomResults.Problem);
        });
    }
}
