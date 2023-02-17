namespace testforBohdan.Abstractions.Entities;

public class Note : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}