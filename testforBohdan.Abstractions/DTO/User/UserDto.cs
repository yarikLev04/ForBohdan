using System.ComponentModel.DataAnnotations;
using testforBohdan.Abstractions.DTO.Note;

namespace testforBohdan.Abstractions.DTO.User;

public class UserDto
{
    [Required]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public List<NoteDto> Notes { get; set; }
}