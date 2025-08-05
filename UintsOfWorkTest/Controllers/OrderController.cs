using Microsoft.AspNetCore.Mvc;
using UintsOfWorkTest.Dtos;
using UintsOfWorkTest.Services;
using UintsOfWorkTest.UnitsOfWork;

namespace UintsOfWorkTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: api/order
        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _orderService.CreateOrderAsync(request.CustomerName, request.Product);
            return Ok("Ordine creato con successo");
        }

        // POST: api/order
        [HttpPost("order2")]
        public async Task<IActionResult> CreateOrder2([FromBody] CreateOrderRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _orderService.CreateOrderAsync2(request.CustomerName, request.Product);
            return Ok("Ordine creato con successo");
        }

        //[HttpGet("testMethods")]
        //public async Task<IActionResult> testMethods([FromBody] CreateOrderRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    await _customerService.CreateOrderAsync2(request.CustomerName, request.Product);
        //    return Ok("Ordine creato con successo");
        //}

        //// GET: api/order/{id}
        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetOrder(int id, [FromServices] IUnitOfWork unitOfWork)
        //{
        //    var order = await unitOfWork.Orders.GetByIdAsync(id);
        //    if (order == null)
        //        return NotFound();

        //    return Ok(new
        //    {
        //        order.Id,
        //        order.Product,
        //        CustomerName = order.Customer?.Name
        //    });
        //}
    }
}
