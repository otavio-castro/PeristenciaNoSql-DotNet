using PeristenciaNoSql.Models;

namespace PeristenciaNoSql.Services.Interfaces
{
    public interface IAlunosServices
    {
        // Create - Post
        Task<Aluno> CreateAsync(Aluno aluno);

        // Read All - Get
        Task<List<Aluno>> GetAsync();

        // Read by Email - Get
        Task<Aluno> GetByEmailAsync(string email);

        // Read by Id - Get
        Task<Aluno> GetByIdAsync(string id);

        // Update - Put/Patch
        Task UpdateAsync(string id, Aluno alunoAtualizado);

        // Delete - Delete
        Task RemoveAsync(string id);

        // Delete by Email - Delete
        Task RemoveByEmailAsync(string email);
    }
}