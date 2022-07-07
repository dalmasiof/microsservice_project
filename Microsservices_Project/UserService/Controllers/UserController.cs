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
            var userList = await _userService.Get(Id);
            return Ok(userList);
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
                return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Put(UserVM userDTO)
        {
            return Ok(await _userService.Update(userDTO));
        }
    }
}
