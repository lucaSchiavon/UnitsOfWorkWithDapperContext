using Microsoft.AspNetCore.Mvc;
using UintsOfWorkTest.Dtos;
using UintsOfWorkTest.Services;
using UintsOfWorkTest.UnitsOfWork;

namespace UintsOfWorkTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("testMethods")]
        public async Task<IActionResult> testMethods()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //qui vengono testati un po' di metodi
            //await _customerService.RunExamplesDapperAsync();
            await _customerService.RunExamplesDapperSimpleCrud();
            return Ok("Fine del test");
        }


    }
}
