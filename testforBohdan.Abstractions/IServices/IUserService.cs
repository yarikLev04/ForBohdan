using System.Linq.Expressions;
using testforBohdan.Abstractions.DTO.User;
using testforBohdan.Abstractions.Entities;

namespace testforBohdan.Abstractions.IServices;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync(Expression<Func<User, bool>>? filter = null);
    Task<UserDto> GetAsync(int id);
    Task CreateAsync(User entity);
    Task DeleteAsync(int id);
    Task SaveAsync();
    Task<User> UpdateAsync(int id, UserUpdateDto model);
}