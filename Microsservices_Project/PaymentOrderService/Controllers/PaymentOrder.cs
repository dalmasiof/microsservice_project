using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentOrderService.Service;
using PaymentOrderService.ViewModels;

namespace PaymentOrderService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentOrderController : ControllerBase
    {
        private readonly IPOService _pOServicxe;

        public PaymentOrderController(IPOService pOServicxe)
        {
            _pOServicxe = pOServicxe;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var userList = await _pOServicxe.Get();
            return Ok(userList);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Get(long Id)
        {
            var Po = await _pOServicxe.Get(Id);
            if (Po == null)
            {
                return BadRequest("Po not found");
            }
            else
            {
                return Ok(Po);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(PoVm poVm)
        {
            return Ok(await _pOServicxe.Create(poVm));
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            if (await _pOServicxe.Delete(Id))
                return Ok();
            else
                return BadRequest("Po not found");
        }

        [HttpPut]
        public async Task<ActionResult> Put(PoVm poVm)
        {
            return Ok(await _pOServicxe.Update(poVm));
        }
    }
}
