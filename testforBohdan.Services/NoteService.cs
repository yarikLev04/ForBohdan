using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using testforBohdan.Abstractions.DTO.Note;
using testforBohdan.Abstractions.Entities;
using testforBohdan.Abstractions.IServices;
using testforBohdan.Data;

namespace testforBohdan.Services;

public class NoteService : INoteService
{
    private readonly AppDbContext _db;
    internal DbSet<Note> dbset;
    private readonly IMapper _mapper;

    public NoteService(AppDbContext db, IMapper mapper)
    {
        _db = db;
        dbset = _db.Set<Note>();
        _mapper = mapper;
    }
    public async Task<List<NoteDto>> GetAllAsync(Expression<Func<Note, bool>>? filter = null)
    {
        var query = dbset;

        if (filter != null)
        {
            query.Where(filter);
        }

        return await query
            .ProjectTo<NoteDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<NoteDto> GetAsync(int id)
    {
        var note = await dbset
            .Where(n => n.Id == id)
            .FirstOrDefaultAsync();

        var mappedNote = _mapper.Map<NoteDto>(note);
        
        return mappedNote;
    }

    public async Task CreateAsync(Note entity)
    {
        await dbset.AddAsync(entity);
        await SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var note = await dbset.FirstOrDefaultAsync(u => u.Id == id);
        
        dbset.Remove(note);
        await SaveAsync();
    }
    public async Task<Note> UpdateAsync(int id, NoteUpdateDto model)
    {
        var note = dbset.FirstOrDefault(n => n.Id == id);
        
        note.Title = model.Title;
        note.Description = model.Description;
        note.Color = model.Color;
        
        dbset.Update(note);
        await SaveAsync();
        return note;
    }
    
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}