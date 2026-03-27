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
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CustomersController(IRepository customersRepository, IMapper mapper)
        {
            _repository = customersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _repository.GetCustomersAsync();
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDtos);
        }


        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] CustomerForCreationDto customerDto)
        {
            var customerEntity = _mapper.Map<Customer>(customerDto);
            var result = await _repository.CreateCustomerAsync(customerEntity);
            if (!result)
            {
                return BadRequest("Failed to create customer.");
            }
            return CreatedAtAction(nameof(GetCustomers), new { id = customerEntity.Id }, customerDto);
        }
    }
}
