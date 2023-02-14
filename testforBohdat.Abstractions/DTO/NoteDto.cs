using System.ComponentModel.DataAnnotations;

namespace testforBohdat.Abstractions.DTO;

public class NoteDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
}