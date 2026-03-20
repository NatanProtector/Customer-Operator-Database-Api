using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CustomerOperatorDatabaseApi.Entities
{
    public class Email
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Address { get; set; }

        public List<Operator> Operators { get; set; } = new();

    }
}
