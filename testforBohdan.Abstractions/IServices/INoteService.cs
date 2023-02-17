using System.Linq.Expressions;
using testforBohdan.Abstractions.DTO.Note;
using testforBohdan.Abstractions.Entities;

namespace testforBohdan.Abstractions.IServices;

public interface INoteService
{
    Task<List<NoteDto>> GetAllAsync(Expression<Func<Note, bool>>? filter = null);
    Task<NoteDto> GetAsync(int id);
    Task CreateAsync(Note entity);
    Task DeleteAsync(int id);
    Task SaveAsync();
    Task<Note> UpdateAsync(int id, NoteUpdateDto model);
}