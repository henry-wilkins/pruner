using System;
using MyApp.Models;

namespace MyApp.Services;

public interface IAuthService
{
    bool AuthenticateUser(string username, string password);
    Session CreateSession(int userId);
}

public class AuthService : IAuthService
{
    private readonly IUserRepository _repo;

    public AuthService(IUserRepository repo)
    {
        _repo = repo;
    }

    public bool AuthenticateUser(string username, string password)
    {
        var user = _repo.FindByUsername(username);
        if (user == null)
            return false;
        return ValidatePassword(user, password);
    }

    public Session CreateSession(int userId)
    {
        var token = GenerateToken(userId);
        return new Session { Token = token, UserId = userId };
    }

    private bool ValidatePassword(User user, string password)
    {
        return HashPassword(password) == user.PasswordHash;
    }

    private string HashPassword(string password)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }

    private string GenerateToken(int userId)
    {
        return Guid.NewGuid().ToString();
    }
}
