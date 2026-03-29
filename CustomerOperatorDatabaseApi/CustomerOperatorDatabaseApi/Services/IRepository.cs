namespace CustomerOperatorDatabaseApi.Services
{
    public interface IRepository
    {
        Task<IEnumerable<Entities.Email>> GetAllEmailsAsync();
        Task<IEnumerable<Entities.Customer>> GetCustomersAsync();
        Task<IEnumerable<Entities.Operator>> GetOperatorsAsync();
        Task<bool> CreateOperatorAsync(Entities.Operator operatorEntity);
        Task<bool> CreateCustomerAsync(Entities.Customer customerEntity);
    }
}
