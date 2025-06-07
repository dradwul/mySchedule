using AutoLife.Domain.Models;
using AutoLife.Lib.Extensions;
using AutoLife.Lib.Interfaces;

namespace AutoLife.Lib.Services;

public class ToDoItemService
{
	private readonly IRepository<ToDoItem> _todoItemRepository;
	public List<ToDoItem> WeeklyPlan { get; set; }
	public List<ToDoItem> AllToDos { get; set; }

	public ToDoItemService(IRepository<ToDoItem> todoItemRepository)
	{
		_todoItemRepository = todoItemRepository;
	}


	public async Task LoadAllTodosAsync()
	{
		AllToDos = await _todoItemRepository.GetAll();
		WeeklyPlan = AllToDos
		   .Where(todo => todo.Date >= DateTime.Now.StartOfWeek(DayOfWeek.Monday) && todo.Date <= DateTime.Now.EndOfWeek(DayOfWeek.Sunday))
		   .ToList();
	}

	public async Task UpdateTodoItemAync(ToDoItem todo)
	{
		await _todoItemRepository.Update(todo);
	}

	public async Task CreateNewTodoAsync(ToDoItem newTodo)
	{
		await _todoItemRepository.Create(newTodo);
	}
}
