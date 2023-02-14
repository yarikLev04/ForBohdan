using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using testforBohdan.Data;
using testforBohdan.Repository.IRepository;

namespace testforBohdan.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;
    internal DbSet<T> dbset;

    public Repository(AppDbContext db)
    {
        _db = db;
        dbset = _db.Set<T>();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = dbset;

        if (filter != null)
        {
            query.Where(filter);
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = dbset;

        if (filter != null)
        {
            query.Where(filter);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await dbset.AddAsync(entity);
        await SaveAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        dbset.Remove(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}