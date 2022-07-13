using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Service.Interfaces;
using PaymentService.ViewModel;

namespace PaymentService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var userList = await _paymentService.Get();
            return Ok(userList);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Get(long Id)
        {
            var payment = await _paymentService.Get(Id);
            if (payment == null)
            {
                return BadRequest("Payment not found");
            }
            else
            {
                return Ok(payment);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(PaymentVM userDTO)
        {
            return Ok(await _paymentService.Create(userDTO));
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            if (await _paymentService.Delete(Id))
                return Ok();
            else
                return BadRequest("Payment not found");
        }

        [HttpPut]
        public async Task<ActionResult> Put(PaymentVM userDTO)
        {
            return Ok(await _paymentService.Update(userDTO));
        }
    }
}
