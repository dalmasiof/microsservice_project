namespace UserService.Requisitions
{
    using Entities.Entities;
    using UserService.Model;

    public interface IReqs
    {
         public Task<UserDTO> Get(int Id);
        public Task<UserDTO> Post(UserDTO UserDTO);
        public Task<UserDTO> Put(UserDTO UserDTO);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<UserDTO>> Get();

    }
}
