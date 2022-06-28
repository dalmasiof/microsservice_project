using MessageBus;

namespace UserService.Model
{
    public class UserDTO:BaseMessage
    {
        public string  Name { get; set; }
        public string  LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }



    }
}
