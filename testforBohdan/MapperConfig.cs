using AutoMapper;
using testforBohdan.Abstractions.DTO;
using testforBohdan.Abstractions.Entities;

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