public interface IUserRepository
{
    UserData Create(UserData entity);
    UserData Update(UserData entity);
    UserData Delete(UserData entity);
    IEnumerable<UserData> Get(UserData entity);
    bool SaveChanges();
}

