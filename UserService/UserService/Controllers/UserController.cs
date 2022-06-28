using BLL.DTO;
using MessageBus.RabbitMQSender;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRabbitMQSender _rabbitMQSender;

        public UserController(IRabbitMQSender rabbitMQSender)
        {
            _rabbitMQSender = rabbitMQSender;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Teste");
        }


        [HttpPost]
        public ActionResult Post(User user)
        {
            _rabbitMQSender.SendMessage(user, "User_Queue");
            return Ok("message success");
        }
    }
}
