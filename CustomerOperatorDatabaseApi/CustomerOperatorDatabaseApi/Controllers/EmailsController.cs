using AutoMapper;
using CustomerOperatorDatabaseApi.Entities;
using CustomerOperatorDatabaseApi.Model;
using CustomerOperatorDatabaseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOperatorDatabaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailsController : ControllerBase
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public EmailsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailDto>>> GetEmails()
        {
            try
            {
                IEnumerable<Email> emails = await _repository.GetAllEmailsAsync();
                IEnumerable<EmailDto> emailDtos = _mapper.Map<IEnumerable<EmailDto>>(emails);
                return Ok(emailDtos);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while retrieving emails: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving emails.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(Guid id)
        {
            // Logic to delete the email by

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<EmailDto>>> CreateEmails(
            [FromBody] IEnumerable<EmailForCreationDto> emailForCreationDto)
        {
            IEnumerable<Email> emailEntities = _mapper.Map<IEnumerable<Email>>(emailForCreationDto);

            var result = await _repository.CreateEmailsAsync(emailEntities);
            if (!result)
            {
                return BadRequest("Failed to create emails.");
            }

            var emailDtos = _mapper.Map<IEnumerable<EmailDto>>(emailEntities);
            return CreatedAtAction(nameof(GetEmails), emailDtos);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEmail(EmailDto emailDto)
        {
            // Logic to update the email
            return NoContent();
        }
    }
}
