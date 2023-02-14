using testforBohdan.Models;

namespace testforBohdan.Repository.IRepository;

public interface INoteRepository : IRepository<Note>
{
    Task<Note> UpdateAsync(Note entity);
}