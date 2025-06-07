using AutoLife.Domain.Models;
using AutoLife.Lib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoLife.Data.Repositories;

public class ToDoItemRepository : IRepository<ToDoItem>
{
	private readonly IDbContextFactory<ApplicationDbContext> _context;

	public ToDoItemRepository(IDbContextFactory<ApplicationDbContext> context)
	{
		_context = context;
	}

	public async Task<bool> Create(ToDoItem todoItem)
	{
		var context = _context.CreateDbContext();
		if (todoItem == null)
		{
			return false;
		}

		context.ToDoItems.Add(todoItem);
		await context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Remove(ToDoItem todoItem)
	{
		var context = _context.CreateDbContext();
		if (todoItem == null)
		{
			return false;
		}

		context.ToDoItems.Remove(todoItem);
		await context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Update(ToDoItem todoItem)
	{
		var context = _context.CreateDbContext();
		if (todoItem == null)
		{
			return false;
		}

		var itemToUpdate = await context.ToDoItems.FirstOrDefaultAsync(item => item.Id == todoItem.Id);

		if (itemToUpdate == null)
		{
			return false;
		}

		itemToUpdate.Title = todoItem.Title;
		itemToUpdate.Description = todoItem.Description;
		itemToUpdate.Date = todoItem.Date;
		itemToUpdate.IsCompleted = todoItem.IsCompleted;
		await context.SaveChangesAsync();

		return true;
	}

	public async Task<List<ToDoItem>> GetAll()
	{
		var context = _context.CreateDbContext();
		return await context.ToDoItems
			.Include(todo => todo.AssignedPerson)
			.ToListAsync();
	}
}
