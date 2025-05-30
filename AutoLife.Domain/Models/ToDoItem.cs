using AutoLife.Domain.Enums;

namespace AutoLife.Domain.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public ToDoCategory Category { get; set; } = ToDoCategory.Other;
    public bool IsCompleted { get; set; }
}
