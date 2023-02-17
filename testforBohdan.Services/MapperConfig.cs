using AutoMapper;
using testforBohdan.Abstractions.DTO.Note;
using testforBohdan.Abstractions.DTO.User;
using testforBohdan.Abstractions.Entities;

namespace testforBohdan.Services;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Note, NoteDto>().ReverseMap();
        CreateMap<Note, NoteUpdateDto>().ReverseMap();
        CreateMap<Note, NoteCreateDto>().ReverseMap();
        
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserCreateDto>().ReverseMap();
    } 
}