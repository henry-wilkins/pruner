using Xunit;
using MyApp.Services;
using MyApp.Models;

namespace MyApp.Tests;

public class AuthServiceTests
{
    [Fact]
    public void AuthenticateUser_ValidCredentials_ReturnsTrue()
    {
        var repo = new FakeUserRepository();
        var svc = new AuthService(repo);
        var result = svc.AuthenticateUser("admin", "password");
        Assert.True(result);
    }

    [Fact]
    public void AuthenticateUser_InvalidUser_ReturnsFalse()
    {
        var repo = new FakeUserRepository();
        var svc = new AuthService(repo);
        var result = svc.AuthenticateUser("unknown", "password");
        Assert.False(result);
    }

    [Fact]
    public void CreateSession_ReturnsSessionWithToken()
    {
        var repo = new FakeUserRepository();
        var svc = new AuthService(repo);
        var session = svc.CreateSession(1);
        Assert.NotNull(session.Token);
    }
}
