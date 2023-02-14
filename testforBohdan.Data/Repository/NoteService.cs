using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using testforBohdat.Abstractions.Entities;
using testforBohdat.Abstractions.IRepository;

namespace testforBohdat.Data.Repository;

public class NoteService : INoteService
{
    private readonly AppDbContext _db;
    internal DbSet<Note> dbset;


    public NoteService(AppDbContext db)
    {
        _db = db;
        dbset = _db.Set<Note>();
    }
    public async Task<List<Note>> GetAllAsync(Expression<Func<Note, bool>>? filter = null)
    {
        IQueryable<Note> query = dbset;

        if (filter != null)
        {
            query.Where(filter);
        }

        return await query.ToListAsync();
    }

    public async Task<Note> GetAsync(Expression<Func<Note, bool>>? filter = null)
    {
        IQueryable<Note> query = dbset;

        if (filter != null)
        {
            query.Where(filter);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Note entity)
    {
        await dbset.AddAsync(entity);
        await SaveAsync();
    }

    public async Task DeleteAsync(Note entity)
    {
        dbset.Remove(entity);
        await SaveAsync();
    }
    public async Task<Note> UpdateAsync(Note entity)
    {
        dbset.Update(entity);
        await SaveAsync();
        return entity;
    }
    
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}