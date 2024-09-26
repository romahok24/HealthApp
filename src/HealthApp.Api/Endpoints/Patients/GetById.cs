using HealthApp.Application.Patients.GetById;
using HealthApp.Web.Api.Extensions;
using HealthApp.Web.Api.Infrastructure;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthApp.Web.Api.Endpoints.Patients;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("patients/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetPatientByIdQuery(id);

            var result = await sender.Send(query, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithMetadata(new SwaggerOperationAttribute(
            summary: "Получение пациента по ID.",
            description: "Эндпоинт для получения пациента по его идентификатору."));
    }
}
