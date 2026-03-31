namespace MyApp.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}

public class Session
{
    public string Token { get; set; }
    public int UserId { get; set; }
}

public enum UserRole
{
    Admin,
    User,
    Guest,
}
