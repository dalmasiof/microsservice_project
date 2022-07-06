using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserDataBDController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserDataBDController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var user = _userRepository.Get();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(UserData user)
        {
            if (_userRepository.Create(user) != null)
                return Ok(user);
            else
                return StatusCode(500);
        }

        [HttpPut()]
        public IActionResult Put(UserData user)
        {
            if (_userRepository.Update(user) != null)
                return Ok(user);
            else
                return StatusCode(500);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var user = _userRepository.GetById(Id);

            if (user != null)
            {
                if (_userRepository.Delete(user))
                    return Ok();
                else 
                    return BadRequest();

            }
            else  
                return StatusCode(400);
        }
    }
}
