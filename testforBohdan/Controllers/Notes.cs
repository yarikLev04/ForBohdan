using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using testforBohdan.Models;
using testforBohdan.Models.DTO;
using testforBohdan.Repository.IRepository;

namespace testforBohdan.Controllers;

[ApiController]
[Route("[controller]")]
public class Notes : ControllerBase
{
    private readonly INoteRepository _dbNote;
    private readonly IMapper _mapper;
    
    public Notes(INoteRepository dbNote, IMapper mapper)
    {
        _dbNote = dbNote;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Note>>> GetNotes()
    {
        try
        {
            IEnumerable<Note> response = await _dbNote.GetAllAsync();
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("{id:int}", Name ="GetNote")]
    public async Task<ActionResult<Note>> GetNote(int id)
    {
        try
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var note = await _dbNote.GetAsync(n => n.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            var mapNote = _mapper.Map<Note>(note);
            return Ok(mapNote);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Note>> CreateNote([FromBody] NoteCreateDto model)
    {
        try
        {
            if (model == null)
            {
                return BadRequest();
            }

            Note newNote = _mapper.Map<Note>(model);

            await _dbNote.CreateAsync(newNote);
            return Ok(newNote);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Note>> UpdateNote(int id, [FromBody] NoteUpdateDto model)
    {
        try
        {
            if (model == null || model.Id != id)
            {
                return BadRequest();
            }

            Note newModel = _mapper.Map<Note>(model);
            await _dbNote.UpdateAsync(newModel);
            return Ok(newModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteNote(int id)
    {
        try
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}