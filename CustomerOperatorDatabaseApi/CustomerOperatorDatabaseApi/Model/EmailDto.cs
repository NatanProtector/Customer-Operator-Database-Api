using System.ComponentModel.DataAnnotations;

namespace CustomerOperatorDatabaseApi.Model
{
    public class EmailDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }

    }
}
