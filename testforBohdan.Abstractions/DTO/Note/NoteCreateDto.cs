using System.ComponentModel.DataAnnotations;

namespace testforBohdan.Abstractions.DTO.Note;

public class NoteCreateDto
{
    [Required]
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    [Required]
    public int UserId { get; set; }
}