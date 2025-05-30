using AutoLife.Domain.Models;
using AutoLife.Lib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoLife.Data.Repositories;

public class UserProfileRepository : IRepository<UserProfile>
{
	private readonly ApplicationDbContext _context;

	public UserProfileRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<bool> Create(UserProfile userProfile)
	{
		if (userProfile == null)
		{
			return false;
		}

		_context.UserProfiles.Add(userProfile);
		await _context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Remove(UserProfile userProfile)
	{
		if (userProfile == null)
		{
			return false;
		}

		_context.UserProfiles.Remove(userProfile);
		await _context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Update(UserProfile userProfile)
	{
		if (userProfile == null)
		{
			return false;
		}

		_context.UserProfiles.Update(userProfile);
		await _context.SaveChangesAsync();

		return true;
	}

	public async Task<List<UserProfile>> GetAll()
	{
		return await _context.UserProfiles.ToListAsync();
	}
}
