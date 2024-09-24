using HealthApp.Domain.Abstractions.Specification;
using HealthApp.Domain.Patients;

namespace HealthApp.Application.Abstractions.Repositories;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllAsync(Specification<Patient> specification, CancellationToken cancellationToken);
    Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(Patient patient, CancellationToken cancellationToken);
    Task UpdateAsync(Patient patient, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
