using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using PaymentOrderDB.Data.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentOrderDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoDbController : ControllerBase
    {
        private readonly IPORepository _poRepository;
        public PoDbController(IPORepository poRepository)
        {
            _poRepository = poRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var paymentOrder = _poRepository.Get();
            return Ok(paymentOrder);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var paymentOrder = _poRepository.GetById(id);
            return Ok(paymentOrder);
        }

        [HttpPost]
        public IActionResult Post(PaymentOrderData paymentOrder)
        {
            if (_poRepository.Create(paymentOrder) != null)
                return Ok(paymentOrder);
            else
                return StatusCode(500);
        }

        [HttpPut()]
        public IActionResult Put(PaymentOrderData paymentOrder)
        {
            if (_poRepository.Update(paymentOrder) != null)
                return Ok(paymentOrder);
            else
                return StatusCode(500);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var paymentOrder = _poRepository.GetById(Id);

            if (paymentOrder != null)
            {
                if (_poRepository.Delete(paymentOrder))
                    return Ok();
                else
                    return BadRequest();

            }
            else
                return StatusCode(400);
        }
    }
}
