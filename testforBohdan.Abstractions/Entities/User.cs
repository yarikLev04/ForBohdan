namespace testforBohdan.Abstractions.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public List<Note> Notes { get; set; }
}