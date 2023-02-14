using System.ComponentModel.DataAnnotations;

namespace testforBohdan.Models.DTO;

public class NoteCreateDto
{
    [Required]
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
}