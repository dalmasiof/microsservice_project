using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Model;
using UserService.Service.Interface;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
           var userList = await _userService.Get();
            return Ok(userList);
        }

        [HttpPost]
        public ActionResult Post(UserDTO userDTO)
        {
            _userService.Create(userDTO);
                return Ok();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult Put()
        {
            return Ok();
        }
    }
}
