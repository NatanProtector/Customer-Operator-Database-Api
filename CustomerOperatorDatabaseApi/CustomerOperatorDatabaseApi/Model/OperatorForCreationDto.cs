using System.ComponentModel.DataAnnotations;

namespace CustomerOperatorDatabaseApi.Model
{
    public class OperatorForCreationDto
    {
        [Required(ErrorMessage = "you must provide a name value.")]
        [MaxLength(100, ErrorMessage = "The name cannot exceed 100 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "you must provide at least one email.")]
        public required List<string> Emails { get; set; }
    }
}
