using AutoMapper;
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
            var operatorDtos = _mapper.Map<IEnumerable<OperatorDto>>(operators);
            return Ok(operatorDtos);
        }
    }
}
