using testforBohdan.Data;
using testforBohdan.Models;
using testforBohdan.Repository.IRepository;

namespace testforBohdan.Repository;

public class NoteRepository : Repository<Note>, INoteRepository
{
    private readonly AppDbContext _db;

    public NoteRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<Note> UpdateAsync(Note entity)
    {
        _db.Notes.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}