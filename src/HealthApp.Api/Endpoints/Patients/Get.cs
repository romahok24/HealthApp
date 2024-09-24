using HealthApp.Application.Patients.Get;
using HealthApp.Web.Api.Extensions;
using HealthApp.Web.Api.Infrastructure;
using MediatR;

namespace HealthApp.Web.Api.Endpoints.Patients;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("patients", async (List<string> birthDates, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetPatientQuery(birthDates);

            var result = await sender.Send(query, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        });
    }
}
