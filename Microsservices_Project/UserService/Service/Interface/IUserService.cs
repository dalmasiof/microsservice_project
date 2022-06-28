using UserService.Model;

namespace UserService.Service.Interface
{
    public interface IUserService
    {
        bool SendMessage(UserDTO userDTO);


    }
}
