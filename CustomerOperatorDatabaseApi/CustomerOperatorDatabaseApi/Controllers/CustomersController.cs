using CustomerOperatorDatabaseApi.Entities;
using CustomerOperatorDatabaseApi.Model;
using CustomerOperatorDatabaseApi.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace CustomerOperatorDatabaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _customersRepository.GetCustomersAsync();
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDtos);
        }
    }
}
