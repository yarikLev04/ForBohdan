using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using testforBohdan.Abstractions.DTO.User;
using testforBohdan.Abstractions.Entities;
using testforBohdan.Abstractions.IServices;

namespace testforBohdan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{ 
    private readonly IUserService _dbUsers;
    private readonly IMapper _mapper;
    
    public UsersController(IUserService dbUsers, IMapper mapper)
    {
        _dbUsers = dbUsers;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<object> GetUsers()
    {
        var users = await _dbUsers.GetAllAsync();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<object> GetUser(int id)
    {
        if (id == default)
        {
            return BadRequest("Id is required");
        }

        var user = await _dbUsers.GetAsync(id);
            
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<object> CreateUser([FromBody] UserCreateDto model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        var newUser = _mapper.Map<User>(model);

        await _dbUsers.CreateAsync(newUser);
        return Ok(newUser);
    }
    
    [HttpPut("{id:int}")]
    public async Task<object> UpdateUser(int id, [FromBody] UserUpdateDto model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        var user = await _dbUsers.GetAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }

        var updatedUser = await _dbUsers.UpdateAsync(id, model);
        return Ok(_mapper.Map<UserDto>(updatedUser ));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<object> DeleteUser(int id)
    {
        if (id == default )
        {
            return BadRequest();
        }

        var user = await _dbUsers.GetAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }

        await _dbUsers.DeleteAsync(id);
        return Ok();
    }
}