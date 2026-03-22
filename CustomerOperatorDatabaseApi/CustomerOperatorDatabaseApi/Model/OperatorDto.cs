using CustomerOperatorDatabaseApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace CustomerOperatorDatabaseApi.Model
{
    public class OperatorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Emails { get; set; } = new();
    }
}
