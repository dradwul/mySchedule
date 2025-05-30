using AutoLife.Domain.Enums;

namespace AutoLife.Domain.Models;

public class WeeklyPlanItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public ToDoCategory Category { get; set; } = ToDoCategory.Other;
    public UserProfile? AssignedPerson { get; set; }
}