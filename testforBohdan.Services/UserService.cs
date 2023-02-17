using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using testforBohdan.Abstractions.DTO.User;
using testforBohdan.Abstractions.Entities;
using testforBohdan.Abstractions.IServices;
using testforBohdan.Data;

namespace testforBohdan.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _db;
    internal DbSet<User> dbsetUser;
    private readonly IMapper _mapper;
    
    public UserService(AppDbContext db, IMapper mapper)
    {
        _db = db;
        dbsetUser = _db.Set<User>();
        _mapper = mapper;
    }
    
    public async Task<List<UserDto>> GetAllAsync(Expression<Func<User, bool>>? filter = null)
    {
        var query = dbsetUser.Include(u => u.Notes);

        if (filter != null)
        {
            query.Where(filter);
        }

        return await query
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();;
    }

    public async Task<UserDto> GetAsync(int id)
    {
        var query = await dbsetUser
            .Include(u => u.Notes)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        var mappedUser = _mapper.Map<UserDto>(query);
        
        return mappedUser;
    }

    public async Task CreateAsync(User entity)
    {
        await dbsetUser.AddAsync(entity);
        await SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await dbsetUser.FirstOrDefaultAsync(u => u.Id == id);

        dbsetUser.Remove(user);
        await SaveAsync();
    }
    
    public async Task<User> UpdateAsync(int id, UserUpdateDto model)
    {
        var user = await dbsetUser.FirstOrDefaultAsync(u => u.Id == id);

        user.Name = model.Name;
        
        dbsetUser.Update(user);
        await SaveAsync();
        return user;
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}