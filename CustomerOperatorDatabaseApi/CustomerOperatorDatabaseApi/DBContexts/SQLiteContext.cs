using CustomerOperatorDatabaseApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerOperatorDatabaseApi.DBContexts
{
    public class SQLiteContext: DbContext
    {
        public DbSet<Entities.Email> Emails { get; set; }
        public DbSet<Entities.Customer> Customers { get; set; }
        public DbSet<Entities.Operator> Operators { get; set; }
        public SQLiteContext(DbContextOptions<SQLiteContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            // Making the Email.Address property unique to prevent duplicate email addresses in the database
            modelBuilder.Entity<Email>()
            .HasIndex(e => e.Address)
            .IsUnique();

            // Making the Customer.Name property unique to prevent duplicate customer names in the database
            modelBuilder.Entity<Customer>()
            .HasIndex(e => e.Name)
            .IsUnique();

            // Making the Operator.Name property unique to prevent duplicate operator names in the database
            modelBuilder.Entity<Operator>()
            .HasIndex(e => e.Name)
            .IsUnique();

            // Configure one-to-many relationship: Operator -> Customers
            modelBuilder.Entity<Operator>()
                .HasMany(o => o.Customers)
                .WithOne(c => c.Operator)
                .HasForeignKey(c => c.OperatorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Define Operator IDs for reference
            var attId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var verizonId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
            var tmobileId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
            var sprintId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

            // Seed Operators
            modelBuilder.Entity<Operator>().HasData(
                new Operator { Id = attId, Name = "AT&T" },
                new Operator { Id = verizonId, Name = "Verizon" },
                new Operator { Id = tmobileId, Name = "T-Mobile" },
                new Operator { Id = sprintId, Name = "Sprint" }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = Guid.Parse("c1111111-1111-1111-1111-111111111111"), Name = "John Doe", OperatorId = attId },
                new Customer { Id = Guid.Parse("c2222222-2222-2222-2222-222222222222"), Name = "Jane Smith", OperatorId = verizonId },
                new Customer { Id = Guid.Parse("c3333333-3333-3333-3333-333333333333"), Name = "Bob Johnson", OperatorId = tmobileId },
                new Customer { Id = Guid.Parse("c4444444-4444-4444-4444-444444444444"), Name = "Alice Williams", OperatorId = attId },
                new Customer { Id = Guid.Parse("c5555555-5555-5555-5555-555555555555"), Name = "Charlie Brown", OperatorId = sprintId }
            );

            // Define Email IDs for reference
            var email1Id = Guid.Parse("e1111111-1111-1111-1111-111111111111");
            var email2Id = Guid.Parse("e2222222-2222-2222-2222-222222222222");
            var email3Id = Guid.Parse("e3333333-3333-3333-3333-333333333333");
            var email4Id = Guid.Parse("e4444444-4444-4444-4444-444444444444");

            // Seed Emails
            modelBuilder.Entity<Email>().HasData(
                new Email { Id = email1Id, Address = "contact@att.com" },
                new Email { Id = email2Id, Address = "support@verizon.com" },
                new Email { Id = email3Id, Address = "info@t-mobile.com" },
                new Email { Id = email4Id, Address = "help@sprint.com" }
            );

            // Seed Many-to-Many relationship between Email and Operator
            modelBuilder.Entity<Email>()
                .HasMany(e => e.Operators)
                .WithMany(o => o.Emails)
                .UsingEntity(j => j.HasData(
                    new { EmailsId = email1Id, OperatorsId = attId },
                    new { EmailsId = email2Id, OperatorsId = verizonId },
                    new { EmailsId = email3Id, OperatorsId = tmobileId },
                    new { EmailsId = email4Id, OperatorsId = sprintId },
                    // Example: AT&T has multiple contact emails
                    new { EmailsId = email2Id, OperatorsId = attId }
                ));

        }
    }
}
