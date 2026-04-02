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
        public async Task<ActionResult<IEnumerable<EmailDto>>> CreateEmails([FromBody] List<EmailForCreationDto> emailDtos)

        {
            foreach (var emailDto in emailDtos)
            {
                Console.WriteLine($"Received email for creation: {emailDto.Address}");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (emailDtos == null || !emailDtos.Any())
            {
                return BadRequest("At least one email is required.");
            }

            IEnumerable<Email> emailEntities = _mapper.Map<IEnumerable<Email>>(emailDtos);

            var result = await _repository.CreateEmailsAsync(emailEntities);
            if (!result)
            {
                return BadRequest("Failed to create emails.");
            }

            var createdEmailDtos = _mapper.Map<IEnumerable<EmailDto>>(emailEntities);
            return CreatedAtAction(nameof(GetEmails), createdEmailDtos);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEmail(Guid id, [FromBody] EmailForUpdatingDto emailDto)
        {
           
            var existingEmail = await _repository.GetEmailByIdAsync(id);
            if (existingEmail == null)
            {
                return NotFound($"Email with ID {id} not found.");
            }

            // Check if new address would violate unique constraint
            if (existingEmail.Address != emailDto.Address)
            {
                var emailWithSameAddress = await _repository.GetAllEmailsAsync();
                if (emailWithSameAddress.Any(e => e.Address == emailDto.Address && e.Id != id))
                {
                    return BadRequest($"Email address '{emailDto.Address}' already exists.");
                }
            }

            // Map the updated properties
            _mapper.Map(emailDto, existingEmail);

            try
            { 
                var result = await _repository.UpdateEmailAsync(existingEmail);
                if (!result)
                {
                    return BadRequest("Failed to update email.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while updating email: {ex.Message}");
                return StatusCode(500, "An error occurred while updating email.");
            }
            return NoContent();
        }
    }
}
