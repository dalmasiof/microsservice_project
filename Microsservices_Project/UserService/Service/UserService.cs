using MessageBus;
using UserService.MessageSender.Interfaces;
using UserService.Model;
using UserService.Service.Interface;

namespace UserService.Service
{
    public class User_Service : IUserService
    {
        private readonly IMessageSender _messageSender;
        private readonly string _queuename;

        public User_Service(IMessageSender messageSender)
        {
            _messageSender = messageSender;
            _queuename = "User_Queue";

        }
        public bool SendMessage(UserDTO userDTO)
        {
            //validationProcess
            if (userDTO == null) return false;

            _messageSender.SendMessage(userDTO, _queuename);

            return true;
        }


    }
}
