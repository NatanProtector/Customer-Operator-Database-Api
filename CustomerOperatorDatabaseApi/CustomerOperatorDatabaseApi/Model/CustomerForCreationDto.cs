using System.ComponentModel.DataAnnotations;

namespace CustomerOperatorDatabaseApi.Model
{
    public class CustomerForCreationDto
    {
        [Required(ErrorMessage = "you must provide a name value.")]
        [MaxLength(100, ErrorMessage = "The name cannot exceed 100 characters.")]
        public string Name { get; set; }

        // id of the operator that the customer belongs to
        [Required(ErrorMessage = "you must provide an operatorId value.")]
        public Guid OperatorId { get; set; }
    }
}
