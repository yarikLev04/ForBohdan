using System.ComponentModel.DataAnnotations;

namespace testforBohdan.Abstractions.DTO.User;

public class UserUpdateDto
{
    [Required]
    public int Id { get; set; }
    
    public string Name { get; set; }
}