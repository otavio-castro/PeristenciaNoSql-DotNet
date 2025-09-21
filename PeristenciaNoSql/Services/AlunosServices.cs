using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeristenciaNoSql.Models;
using PeristenciaNoSql.Services.Interfaces;

namespace PeristenciaNoSql.Services
{
    public class AlunosServices : IAlunosServices
    {
        private readonly IMongoCollection<Aluno> _alunosCollection;

        public AlunosServices(IOptions<AlunoDbSettingsConnection> alunoDbSettingsConnection)
        {
            var mongoClient = new MongoClient(alunoDbSettingsConnection.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(alunoDbSettingsConnection.Value.DatabaseName);

            _alunosCollection = mongoDatabase.GetCollection<Aluno>(
                alunoDbSettingsConnection.Value.AlunosCollectionName);
        }

        // Create - Post
        public async Task<Aluno> CreateAsync(Aluno aluno)
        {
            await _alunosCollection.InsertOneAsync(aluno);
            return aluno;
        }

        // Read All - Get
        public async Task<List<Aluno>> GetAsync()
        {
            return await _alunosCollection.Find(_ => true).ToListAsync();
        }

        // Read by Email - Get
        public async Task<Aluno> GetByEmailAsync(string email)
        {
            return await _alunosCollection.Find(a => a.Email == email).FirstOrDefaultAsync();
        }

        // Read by Id - Get
        public async Task<Aluno> GetByIdAsync(string id)
        {
            return await _alunosCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        // Update - Put/Patch
        public async Task UpdateAsync(string id, Aluno alunoAtualizado)
        {
            await _alunosCollection.ReplaceOneAsync(a => a.Id == id, alunoAtualizado);
        }

        // Delete - Delete
        public async Task RemoveAsync(string id)
        {
            await _alunosCollection.DeleteOneAsync(a => a.Id == id);
        }

        // Delete by Email - Delete
        public async Task RemoveByEmailAsync(string email)
        {
            await _alunosCollection.DeleteOneAsync(a => a.Email == email);
        }
    }
}