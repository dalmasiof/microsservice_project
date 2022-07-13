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

        [HttpGet("{Id}")]
        public async Task<ActionResult> Get(long Id)
        {
            var user = await _userService.Get(Id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            else
            {
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserVM userDTO)
        {
                return Ok(await _userService.Create(userDTO));
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            if(await _userService.Delete(Id))
                return Ok();
            else
                return BadRequest("User not found");
        }

        [HttpPut]
        public async Task<ActionResult> Put(UserVM userDTO)
        {
            return Ok(await _userService.Update(userDTO));
        }
    }
}
