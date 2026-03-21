namespace CustomerOperatorDatabaseApi.Services
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Entities.Customer>> GetCustomersAsync();
    }
}
