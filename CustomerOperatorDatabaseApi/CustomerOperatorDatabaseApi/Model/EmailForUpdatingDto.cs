using System.ComponentModel.DataAnnotations;

namespace CustomerOperatorDatabaseApi.Model
{
    public class EmailForUpdatingDto
    {

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [MaxLength(200, ErrorMessage = "Email address cannot exceed 200 characters.")]
        public string Address { get; set; }
    }
}
