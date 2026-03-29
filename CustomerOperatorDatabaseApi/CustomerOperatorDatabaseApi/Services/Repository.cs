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

        public async Task<bool> CreateCustomerAsync(Customer customerEntity)
        {
            if (customerEntity == null)
            {
                throw new ArgumentNullException(nameof(customerEntity));
            }

            try
            {
                await _context.Customers.AddAsync(customerEntity);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while adding the operator: {ex.Message}");
                return false;
            }

            return true;
        }

        public async Task<bool> CreateOperatorAsync(Operator operatorEntity)
        {

            if (operatorEntity == null)
            {
                throw new ArgumentNullException(nameof(operatorEntity));
            }

            try {
                // Handle emails: check if they exist, if not create them
                var emailsToLink = new List<Email>();

                foreach (var email in operatorEntity.Emails)
                {
                    // Check if email already exists in database
                    var existingEmail = await _context.Emails
                        .FirstOrDefaultAsync(e => e.Address == email.Address);

                    if (existingEmail != null)
                    {
                        // Use existing email
                        emailsToLink.Add(existingEmail);
                    }
                    else
                    {
                        throw new Exception($"Email address '{email.Address}' does not exist in the database. Please create it first before linking to an operator.");
                    }
                }

                // Replace the emails collection with the processed list
                operatorEntity.Emails = emailsToLink;

                await _context.Operators.AddAsync(operatorEntity);

                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while adding the operator: {ex.Message}");
                return false;
            }

            return true;
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
