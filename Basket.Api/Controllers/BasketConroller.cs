using Basket.Api.Entities;
using Basket.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
       // private readonly EventBusRabbitMQProducer eventBusRabbitMQProducer;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BasketModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketModel>> GetGroup(string name)
        {
            var group = await _repository.GetGroup(name);
            return Ok(group ?? new BasketModel(name));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketModel>> UpdateGroup(BasketModel group)
        {
            var updatedGroup = await _repository.UpdateGroup(group);
            return Ok(updatedGroup);
        }

        [HttpDelete("{name}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteGroup(string name)
        {
            return Ok(await _repository.DeleteGroup(name));
        }

        [Route("{action}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Checkout([FromBody] BasketController basketCheckout)
        {
            return Accepted();
        }

    }
}
