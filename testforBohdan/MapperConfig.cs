using AutoMapper;
using testforBohdan.Models;
using testforBohdan.Models.DTO;

namespace testforBohdan;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Note, NoteDto>().ReverseMap();
        CreateMap<Note, NoteUpdateDto>().ReverseMap();
        CreateMap<Note, NoteCreateDto>().ReverseMap();
    } 
}