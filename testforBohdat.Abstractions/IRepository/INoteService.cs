using System.Linq.Expressions;
using testforBohdat.Abstractions.Entities;

namespace testforBohdat.Abstractions.IRepository;

public interface INoteService
{
    Task<List<Note>> GetAllAsync(Expression<Func<Note, bool>>? filter = null);
    Task<Note> GetAsync(Expression<Func<Note, bool>>? filter = null);
    Task CreateAsync(Note entity);
    Task DeleteAsync(Note entity);
    Task SaveAsync();
    Task<Note> UpdateAsync(Note entity);
}