using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentDB.Data.Repository;

namespace PaymentDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentDBController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentDBController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var paymentOrder = _paymentRepository.Get();
            return Ok(paymentOrder);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var paymentOrder = _paymentRepository.GetById(id);
            return Ok(paymentOrder);
        }

        [HttpPost]
        public IActionResult Post(PaymentData paymentOrder)
        {
            if (_paymentRepository.Create(paymentOrder) != null)
                return Ok(paymentOrder);
            else
                return StatusCode(500);
        }

        [HttpPut()]
        public IActionResult Put(PaymentData paymentOrder)
        {
            if (_paymentRepository.Update(paymentOrder) != null)
                return Ok(paymentOrder);
            else
                return StatusCode(500);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var paymentOrder = _paymentRepository.GetById(Id);

            if (paymentOrder != null)
            {
                if (_paymentRepository.Delete(paymentOrder))
                    return Ok();
                else
                    return BadRequest();

            }
            else
                return StatusCode(400);
        }
    }
}
