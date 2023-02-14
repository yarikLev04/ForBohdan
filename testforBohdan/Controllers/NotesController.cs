using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using testforBohdat.Abstractions.DTO;
using testforBohdat.Abstractions.Entities;
using testforBohdat.Abstractions.IRepository;

namespace testforBohdan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteService _dbNote;
    private readonly IMapper _mapper;
    
    public NotesController(INoteService dbNote, IMapper mapper)
    {
        _dbNote = dbNote;
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

        var note = await _dbNote.GetAsync(n => n.Id == id);
            
        if (note == null)
        {
            return NotFound();
        }

        var mapNote = _mapper.Map<Note>(note);
        return Ok(mapNote);
    }
    
    [HttpPost]
    public async Task<object> CreateNote([FromBody] NoteCreateDto model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        var newNote = _mapper.Map<Note>(model);

        await _dbNote.CreateAsync(newNote);
        return Ok(newNote);
    }
    
    [HttpPut("{id:int}")]
    public async Task<object> UpdateNote(int id, [FromBody] NoteUpdateDto model)
    {
        if (model == null || model.Id != id)
        {
            return BadRequest();
        }

        var newModel = _mapper.Map<Note>(model);
        await _dbNote.UpdateAsync(newModel);
        return Ok(newModel);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<object> DeleteNote(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var note = await _dbNote.GetAsync(u => u.Id == id);
        if (note == null)
        {
            return NotFound();
        }

        await _dbNote.DeleteAsync(note);
        return Ok();
    }
}