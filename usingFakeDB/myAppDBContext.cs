using Microsoft.EntityFrameworkCore;

namespace usingFakeDB
{
    public class myAppDBContext: DbContext
    {
        public myAppDBContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}