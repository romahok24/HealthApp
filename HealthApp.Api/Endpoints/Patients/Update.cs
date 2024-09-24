using HealthApp.Application.Patients.Update;
using HealthApp.Web.Api.Extensions;
using HealthApp.Web.Api.Infrastructure;
using MediatR;

namespace HealthApp.Web.Api.Endpoints.Patients;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("patients", async (UpdatePatientCommand command, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(command, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        });
    }
}
