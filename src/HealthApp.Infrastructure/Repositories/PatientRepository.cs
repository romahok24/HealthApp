using HealthApp.Application.Abstractions.Data;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Application.Abstractions.Specification;
using HealthApp.Domain.Patients;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using static HealthApp.Infrastructure.Constants;

namespace HealthApp.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly IMongoDbContext _mongoDbContext;
    private readonly IMongoCollection<Patient> _patients;

    public PatientRepository(IMongoDbContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
        _patients = _mongoDbContext.GetCollection<Patient>(Collections.Patients);
    }

    public async Task<List<Patient>> GetAllAsync(CancellationToken cancellationToken)
    {
        var bsonPatients = await _patients
            .Find("{}")
            .Project("{_id: 0}")
            .ToListAsync(cancellationToken);

        return bsonPatients
            .Select(x => BsonSerializer.Deserialize<Patient>(x))
            .ToList();
    }

    public async Task<Patient> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken)
    {
        var bsonPatient = await _patients
            .Find(x => x.Name.Id == id)
            .Project("{_id: 0}")
            .FirstOrDefaultAsync(cancellationToken);

        return BsonSerializer.Deserialize<Patient>(bsonPatient);
    }

    public async Task<List<Patient>> SearchAsync(
        Specification<Patient> specification,
        CancellationToken cancellationToken)
    {
        var bsonPatients = await _patients
            .Find(specification.ToFilterDefinition())
            .Project("{_id: 0}")
            .ToListAsync(cancellationToken);

        return bsonPatients
            .Select(x => BsonSerializer.Deserialize<Patient>(x))
            .ToList();
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
