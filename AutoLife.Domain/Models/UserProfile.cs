namespace AutoLife.Domain.Models;

public class UserProfile
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public bool Selected { get; set; } = false;
    public List<ToDoItem> ToDoList { get; set; } = [];
}