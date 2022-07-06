namespace UserService.Requisitions
{
    using Entities.Entities;
    using UserService.Model;

    public interface IReqs
    {
        public Task<UserData> Get(long Id);
        public Task<UserData> Post(UserData userData);
        public Task<UserData> Put(UserData userData);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<UserData>> Get();

    }
}
