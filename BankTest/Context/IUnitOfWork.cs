using BankTest.Models;
using BankTest.Repositories;

namespace BankTest.Context
{
	public interface IUnitOfWork
	{
		GenericRepository<Loan> LoanRepository { get; }
		GenericRepository<User> UserRepository { get; }
		GenericRepository<Wallet> WalletRepository { get; }

		void Dispose();
	}
}