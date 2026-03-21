using CustomerOperatorDatabaseApi.DBContexts;
using CustomerOperatorDatabaseApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerOperatorDatabaseApi.Services
{
    public class CustomersRepository: ICustomersRepository
    {
        private readonly SQLiteContext _context;
        public CustomersRepository(SQLiteContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        async public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            IEnumerable<Customer> customers = await _context.Customers
                .Include(c => c.Operator)
                .ToListAsync();

            return customers;
        }
    }
}
