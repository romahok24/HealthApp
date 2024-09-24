using HealthApp.Application.Abstractions.Data;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Domain.Abstractions.Specification;
using HealthApp.Domain.Patients;
using MongoDB.Driver;

namespace HealthApp.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly IMongoDbContext _mongoDbContext;
    private readonly IMongoCollection<Patient> _patients;

    public PatientRepository(IMongoDbContext mongoDbContext)
    {
        // TODO: вынести в константу
        _mongoDbContext = mongoDbContext;
        _patients = _mongoDbContext.GetCollection<Patient>("Patient");
    }

    public async Task<List<Patient>> GetAllAsync(
        Specification<Patient> specification, 
        CancellationToken cancellationToken)
    {
        return await _patients
            .Find(specification.ToExpression())
            .ToListAsync(cancellationToken);
    }

    public async Task<Patient> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken)
    {
        return await _patients
            .Find(x => x.Name.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task CreateAsync(
       Patient patient,
       CancellationToken cancellationToken)
    {
        var options = new InsertOneOptions { BypassDocumentValidation = true };

        await _patients.InsertOneAsync(
            patient, 
            options,
            cancellationToken);
    }

    public async Task UpdateAsync(
        Patient patient, 
        CancellationToken cancellationToken)
    {
        var options = new ReplaceOptions() { BypassDocumentValidation = true };

        await _patients.ReplaceOneAsync(
            x => x.Name.Id == patient.Name.Id, 
            patient, 
            options, 
            cancellationToken);
    }

    public async Task DeleteAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        await _patients.DeleteOneAsync(
            x => x.Name.Id == id,
            cancellationToken);
    }
}
