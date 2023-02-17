using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using testforBohdan.Abstractions.DTO.Note;
using testforBohdan.Abstractions.Entities;
using testforBohdan.Abstractions.IServices;

namespace testforBohdan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteService _dbNote;
    private readonly IUserService _dbUsers;
    private readonly IMapper _mapper;
    
    public NotesController(INoteService dbNote, IUserService dbUsers, IMapper mapper)
    {
        _dbNote = dbNote;
        _dbUsers = dbUsers;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<object> GetNotes()
    {
        var notes = await _dbNote.GetAllAsync();
        return Ok(notes);
    }
    
    [HttpGet("{id}")]
    public async Task<object> GetNote(int id)
    {
        if (id == default)
        {
            return BadRequest("Id is required");
        }

        var note = await _dbNote.GetAsync(id);
            
        if (note == null)
        {
            return NotFound();
        }
        
        return Ok(note);
    }
    
    [HttpPost]
    public async Task<object> CreateNote([FromBody] NoteCreateDto model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        if (model.UserId == default)
        {
            return BadRequest("User id is required");
        }
        
        var user = await _dbUsers.GetAsync(model.UserId);
            
        if (user == null)
        {
            return NotFound();
        }

        var newNote = _mapper.Map<Note>(model);

        await _dbNote.CreateAsync(newNote);
        return Ok(_mapper.Map<NoteDto>(newNote));
    }
    
    [HttpPut("{id:int}")]
    public async Task<object> UpdateNote(int id, [FromBody] NoteUpdateDto model)
    {
        if (model == null)
        {
            return BadRequest();
        }
        
        var note = await _dbNote.GetAsync(id);
        
        if (note == null)
        {
            return NotFound();
        }
        
        var updatedNote = await _dbNote.UpdateAsync(id, model);
        return Ok(_mapper.Map<NoteDto>(updatedNote));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<object> DeleteNote(int id)
    {
        if (id == default)
        {
            return BadRequest();
        }

        var note = await _dbNote.GetAsync(id);
        
        if (note == null)
        {
            return NotFound();
        }

        await _dbNote.DeleteAsync(id);
        return Ok();
    }
}