using CustomerOperatorDatabaseApi.DBContexts;
using CustomerOperatorDatabaseApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerOperatorDatabaseApi.Services
{
    public class Repository: IRepository
    {
        private readonly SQLiteContext _context;
        public Repository(SQLiteContext context)
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

        public async Task<IEnumerable<Operator>> GetOperatorsAsync()
        {
            IEnumerable<Operator> operators = await _context.Operators
                .Include(o => o.Customers)
                .Include(o => o.Emails)
                .ToListAsync();
            return operators;
        }
    }
}
