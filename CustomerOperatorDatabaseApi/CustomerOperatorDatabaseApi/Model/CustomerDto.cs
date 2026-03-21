namespace CustomerOperatorDatabaseApi.Model
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OperatorId { get; set; }
        public string OperatorName { get; set; }
    }
}
