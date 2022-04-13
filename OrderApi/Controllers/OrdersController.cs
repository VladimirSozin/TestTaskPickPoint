using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApi.DAL.Interfaces;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPostTerminalRepository _terminalRepository;

        public OrdersController(
            IOrderRepository orderRepository,
            IPostTerminalRepository terminalRepository)
        {
            _orderRepository = orderRepository;
            _terminalRepository = terminalRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var postTerminal = await _terminalRepository.GetPostTerminalAsync(order.PostTerminalNumber);

            if (postTerminal == null)
                return StatusCode(StatusCodes.Status404NotFound, "Post terminal is not found.");

            if (!postTerminal.IsActive)
                return StatusCode(StatusCodes.Status403Forbidden, "Post terminal is not active.");

            await _orderRepository.InsertAsync(order);
            return Ok();
        }

        [HttpPut]
        [Route("{orderNumber}")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order, [FromRoute] int orderNumber)
        {
            var dbOrder = await GetOrderFromDatabase(orderNumber);

            if (dbOrder == null)
                return StatusCode(StatusCodes.Status404NotFound, $"Order with number={order.Number} is not found.");

            if (dbOrder.Status != order.Status || dbOrder.PostTerminalNumber != order.PostTerminalNumber)
                return StatusCode(StatusCodes.Status400BadRequest, $"Order status and order post terminal number are immutable.");

            var postTerminal = await _terminalRepository.GetPostTerminalAsync(order.PostTerminalNumber);

            if(postTerminal == null)
                return StatusCode(StatusCodes.Status404NotFound, $"Post terminal with number={order.PostTerminalNumber} is not found.");

            await _orderRepository.UpdateAsync(order);
            return Ok();
        }

        [HttpGet]
        [Route("{orderNumber}")]
        public async Task<IActionResult> GetOrderInfo([FromRoute] int orderNumber)
        {
            var order = await _orderRepository.GetOrders()
                .Include(o => o.PostTerminal)
                .FirstOrDefaultAsync(o => o.Number == orderNumber);

            if (order == null)
                return StatusCode(StatusCodes.Status404NotFound, $"Order with number={orderNumber} is not found.");

            return Ok(order);
        }

        [HttpPatch]
        [Route("{orderNumber}/cancel")]
        public async Task<IActionResult> CancelOrder([FromRoute] int orderNumber)
        {
            var order = await GetOrderFromDatabase(orderNumber);

            if (order == null)
                return StatusCode(StatusCodes.Status404NotFound, $"Order with number={orderNumber} is not found.");

            await _orderRepository.CancelAsync(orderNumber);
            return Ok();
        }

        private async Task<Order> GetOrderFromDatabase(int orderNumber)
        {
            return await _orderRepository.GetOrders().FirstOrDefaultAsync(o => o.Number == orderNumber);
        }
    }
}