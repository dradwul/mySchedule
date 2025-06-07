using AutoLife.Domain.Models;

namespace AutoLife.Lib.Services;

public class UserStateService
{
    private List<UserProfile> _userProfiles = [];

    public IReadOnlyList<UserProfile> UserProfiles => _userProfiles;

    public void LoadUsers(List<UserProfile> users)
    {
        _userProfiles = users;
    }

    public void AddUser(UserProfile user)
    {
        _userProfiles.Add(user);
    }

    public void RemoveUser(UserProfile user)
    {
        _userProfiles.Remove(user);
    }

    public void AddTodoToUser(UserProfile user, ToDoItem todoItem)
    {
        var userToUpdate = _userProfiles.FirstOrDefault(u => u.Id == user.Id);
        userToUpdate?.ToDoList.Add(todoItem);
    }
}
