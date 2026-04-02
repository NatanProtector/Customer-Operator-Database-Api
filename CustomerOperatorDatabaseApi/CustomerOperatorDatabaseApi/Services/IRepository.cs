namespace CustomerOperatorDatabaseApi.Services
{
    public interface IRepository
    {
        Task<IEnumerable<Entities.Email>> GetAllEmailsAsync();
        Task<Entities.Email?> GetEmailByIdAsync(Guid id);
        Task<IEnumerable<Entities.Customer>> GetCustomersAsync();
        Task<IEnumerable<Entities.Operator>> GetOperatorsAsync();
        Task<bool> CreateOperatorAsync(Entities.Operator operatorEntity);
        Task<Entities.Operator?> GetOperatorByIdAsync(Guid id);
        Task<bool> DeleteOperatorAsync(Guid id);
        Task<bool> CreateCustomerAsync(Entities.Customer customerEntity);
        Task<bool> CreateEmailsAsync(IEnumerable<Entities.Email> emails);
        Task<bool> UpdateEmailAsync(Entities.Email email);
    }
}
