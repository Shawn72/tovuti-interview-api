using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TovutiAPI.Entities;
using TovutiAPI.Models;

namespace TovutiAPI.DBContexts
{
    public class DatabaseContext:IdentityDbContext<UserModel>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //Add the the entities down here
        public DbSet<CustomerDetails> customer_details { get; set; }
        public DbSet<CustomerAccounts> customer_accounts { get; set; }
        public DbSet<Invoices> invoices { get; set; }
        public DbSet<SalesTransactions> sale_transactions { get; set; }
        //public DbSet<RoleModel> aspnetuserroles { get; set; }
        //public DbSet<UserModel> aspnetusers { get; set; }

    }
}
