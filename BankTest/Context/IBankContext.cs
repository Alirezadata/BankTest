using BankTest.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTest.Context
{
	public interface IBankContext
	{
		DbSet<Loan> Loans { get; set; }
		DbSet<User> Users { get; set; }
		DbSet<Wallet> Wallets { get; set; }

		Task<int> SaveChangesAsync();
	}
}