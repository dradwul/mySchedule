using AutoLife.Domain.Enums;

namespace AutoLife.Domain.Models;

public class ToDoItem
{
    public int Id { get; set; }

    public Guid AssignedPersonId { get; set; }
	public UserProfile AssignedPerson { get; set; }

	public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime? EndDate { get; set; }

    public ToDoCategory Category { get; set; } = ToDoCategory.Other;
    public ToDoWhen WhenToDo { get; set; } = ToDoWhen.Daily;
	public bool IsCompleted { get; set; }
}
