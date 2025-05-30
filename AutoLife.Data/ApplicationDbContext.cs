using AutoLife.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLife.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	public DbSet<ToDoItem> ToDoItems { get; set; }
	public DbSet<UserProfile> UserProfiles { get; set; }
	public DbSet<WeeklyPlan> WeeklyPlans { get; set; }
	public DbSet<WeeklyPlanItem> WeeklyPlanItems { get; set; }
}