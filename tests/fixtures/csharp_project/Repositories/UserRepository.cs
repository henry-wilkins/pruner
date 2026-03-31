using System.Collections.Generic;
using MyApp.Models;

namespace MyApp.Repositories;

public interface IUserRepository
{
    User FindById(int id);
    User FindByUsername(string username);
    void Save(User user);
    List<User> GetAll();
}

public class UserRepository : IUserRepository
{
    private readonly DbContext _db;

    public UserRepository(DbContext db)
    {
        _db = db;
    }

    public User FindById(int id)
    {
        return _db.Query<User>(id);
    }

    public User FindByUsername(string username)
    {
        return _db.QueryWhere<User>(u => u.Username == username);
    }

    public void Save(User user)
    {
        _db.Upsert(user);
    }

    public List<User> GetAll()
    {
        return _db.QueryAll<User>();
    }
}
