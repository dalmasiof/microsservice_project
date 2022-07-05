namespace UserService.Requisitions
{
    using Entities.Entities;
    public interface IReqs
    {
         public Task<UserData> Get(int Id);
        public Task<UserData> Post(UserData userData);
        public Task<UserData> Put(UserData userData);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<UserData>> Get();

    }
}
