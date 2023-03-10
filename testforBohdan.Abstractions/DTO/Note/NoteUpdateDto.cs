using System.ComponentModel.DataAnnotations;

namespace testforBohdan.Abstractions.DTO.Note;

public class NoteUpdateDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
}