public interface IUserRepository
{
    UserData Create(UserData entity);
    UserData Update(UserData entity);
    bool Delete(UserData entity);
    IEnumerable<UserData> Get();
    UserData GetById(long Id);

    bool SaveChanges();
}

