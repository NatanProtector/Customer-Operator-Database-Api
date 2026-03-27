using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOperatorDatabaseApi.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }    

        [ForeignKey(nameof(Operator))]
        public Guid OperatorId { get; set; }
        public Operator Operator { get; set; }
    }
}
