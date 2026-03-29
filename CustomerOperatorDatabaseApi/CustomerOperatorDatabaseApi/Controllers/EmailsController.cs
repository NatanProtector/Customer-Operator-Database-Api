using CustomerOperatorDatabaseApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOperatorDatabaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailDto>>> GetEmails()
        {
            return Ok(new List<EmailDto>
            {
                new EmailDto { Id = Guid.NewGuid(), Address = "test@test.com" }
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(Guid id)
        {
            // Logic to delete the email by

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<EmailDto>> CreateEmail(EmailDto emailDto)
        {
            // Logic to create a new email

            return CreatedAtAction(nameof(GetEmails), new { id = emailDto.Id }, emailDto);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEmail(EmailDto emailDto)
        {
            // Logic to update the email
            return NoContent();
        }
    }
}
