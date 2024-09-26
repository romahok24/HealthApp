using HealthApp.Application.Patients.Search;
using HealthApp.Web.Api.Extensions;
using HealthApp.Web.Api.Infrastructure;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthApp.Web.Api.Endpoints.Patients;

internal sealed class Search : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("patients/search", async (SearchPatientQuery query, ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(query, cancellationToken);

            return result.Match(CustomResults.Ok, CustomResults.Problem);
        })
        .WithMetadata(new SwaggerOperationAttribute(
            summary: "Получение пациентов по дате рождения.",
            description: "Эндпоинт для получения списка пациентов по дате рождения.")); ;
    }
}
