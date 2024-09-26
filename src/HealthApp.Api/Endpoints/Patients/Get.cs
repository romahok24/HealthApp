using HealthApp.Application.Patients.Get;
using HealthApp.Web.Api.Extensions;
using HealthApp.Web.Api.Infrastructure;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthApp.Web.Api.Endpoints.Patients;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("patients", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetPatientQuery();

            var result = await sender.Send(query, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithMetadata(new SwaggerOperationAttribute(
            summary: "Получение всех пациентов.",
            description: "Эндпоинт для получения всех пациентов.")); ;
    }
}
