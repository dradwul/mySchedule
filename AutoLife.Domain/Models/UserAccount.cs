namespace AutoLife.Domain.Models;

public class UserAccount
{
	public Guid Id { get; set; }
	public string Username { get; set; } = default!;
	public string PasswordHash { get; set; } = default!;

	public Guid UserProfileId { get; set; } = default!;
	public UserProfile Profile { get; set; } = default!;
}