namespace testforBohdat.Abstractions.Entities;

public class Note : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
}