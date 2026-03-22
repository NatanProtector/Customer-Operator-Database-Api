namespace CustomerOperatorDatabaseApi.Services
{
    public interface IRepository
    {
        Task<IEnumerable<Entities.Customer>> GetCustomersAsync();
        Task<IEnumerable<Entities.Operator>> GetOperatorsAsync();
    }
}
