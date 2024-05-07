using Exercise.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() { }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        
        public virtual DbSet<TblCustomer> TblCustomers { get; set; }
        public virtual DbSet<tblLogin> TblLogins { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

    }
}
