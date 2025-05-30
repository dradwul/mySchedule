using AutoLife.Domain.Models;
using AutoLife.Lib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoLife.Data.Repositories;

public class UserProfileRepository : IRepository<UserProfile>
{
	private readonly IDbContextFactory<ApplicationDbContext> _context;

	public UserProfileRepository(IDbContextFactory<ApplicationDbContext> context)
	{
		_context = context;
	}

	public async Task<bool> Create(UserProfile userProfile)
	{
		var context = _context.CreateDbContext();
		if (userProfile == null)
		{
			return false;
		}

		context.UserProfiles.Add(userProfile);
		await context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Remove(UserProfile userProfile)
	{
		var context = _context.CreateDbContext();
		if (userProfile == null)
		{
			return false;
		}

		context.UserProfiles.Remove(userProfile);
		await context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Update(UserProfile userProfile)
	{
		var context = _context.CreateDbContext();
		if (userProfile == null)
		{
			return false;
		}

		context.UserProfiles.Update(userProfile);
		await context.SaveChangesAsync();

		return true;
	}

	public async Task<List<UserProfile>> GetAll()
	{
		var context = _context.CreateDbContext();
		return await context.UserProfiles
			.Include(x => x.ToDoList)
			.ToListAsync();
	}
}
