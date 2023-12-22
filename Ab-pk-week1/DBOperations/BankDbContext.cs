using Microsoft.EntityFrameworkCore;
using Ab_pk_week1.Models;

namespace Ab_pk_week1.DBOperations;

public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
    {
    }


    public DbSet<BankAccount> BankAccounts { get; set; }

}

