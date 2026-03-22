using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOperatorDatabaseApi.Entities
{
    [Table("Operators")]
    public class Operator
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
        public List<Email> Emails { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
    }
}
