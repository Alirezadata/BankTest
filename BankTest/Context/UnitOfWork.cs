using BankTest.Models;
using BankTest.Repositories;

namespace BankTest.Context
{
	public class UnitOfWork : IDisposable, IUnitOfWork
	{
		private readonly BankContext _bankContext;
		private GenericRepository<User> _userRepository;
		private GenericRepository<Wallet> _walletRepository;
		private GenericRepository<Loan> _loanRepository;

		public UnitOfWork(BankContext bankContext)
		{
			_bankContext = bankContext;
		}

		public GenericRepository<User> UserRepository
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new GenericRepository<User>(_bankContext);
				}

				return _userRepository;
			}
		}
		public GenericRepository<Wallet> WalletRepository
		{
			get
			{
				if (_walletRepository == null)
				{
					_walletRepository = new GenericRepository<Wallet>(_bankContext);
				}

				return _walletRepository;
			}
		}
		public GenericRepository<Loan> LoanRepository
		{
			get
			{
				if (_loanRepository == null)
				{
					_loanRepository = new GenericRepository<Loan>(_bankContext);
				}

				return _loanRepository;
			}
		}

		public void Dispose()
		{
			_bankContext.Dispose();
		}
	}
}
