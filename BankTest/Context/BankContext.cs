using BankTest.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTest.Context
{
	public class BankContext : DbContext, IBankContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Loan> Loans { get; set; }
		public DbSet<Wallet> Wallets { get; set; }
		public BankContext(DbContextOptions options) : base(options)
		{
		}
		public async Task<int> SaveChangesAsync()
		{
			return await base.SaveChangesAsync();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
