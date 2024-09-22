using HealthApp.Domain.Models;
using System.Collections.Immutable;

namespace HealthApp.Application.Abstractions.Repositories;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<Patient>> GetByDateFilterAsync(string date, CancellationToken cancellationToken);
    Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(Patient patient, CancellationToken cancellationToken);
    Task UpdateAsync(Patient patient, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
