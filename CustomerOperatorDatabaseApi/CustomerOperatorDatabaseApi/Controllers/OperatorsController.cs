using AutoMapper;
using CustomerOperatorDatabaseApi.Entities;
using CustomerOperatorDatabaseApi.Model;
using CustomerOperatorDatabaseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOperatorDatabaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperatorsController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public OperatorsController(IRepository customersRepository, IMapper mapper)
        {
            _repository = customersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOperators()
        {
            var operators = await _repository.GetOperatorsAsync();
            IEnumerable<OperatorDto> operatorDtos = _mapper.Map<IEnumerable<OperatorDto>>(operators);
            return Ok(operatorDtos);
        }

        public async Task<IActionResult> GetOperatorById(Guid id)
        {
            var operatorEntity = await _repository.GetOperatorByIdAsync(id);
            if (operatorEntity == null)
            {
                return NotFound();
            }
            var operatorDto = _mapper.Map<OperatorDto>(operatorEntity);
            return Ok(operatorDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperator([FromBody] OperatorForCreationDto operatorInput)
        {
            Console.WriteLine($"Received operator creation request: Name={operatorInput.Name}, Emails={string.Join("\n- ", operatorInput.Emails)}");
            var operatorEntity = _mapper.Map<Operator>(operatorInput);
            await _repository.CreateOperatorAsync(operatorEntity);
            return CreatedAtAction(nameof(GetOperators), new { id = operatorEntity.Id }, operatorInput);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperator(Guid id) {

            var existingOperator = await _repository.GetOperatorByIdAsync(id);
            if (existingOperator == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.DeleteOperatorAsync(id);
            }
            catch {
                return StatusCode(500, "An error occurred while deleting the operator.");
            }
            return NoContent();

        }
    }
}
