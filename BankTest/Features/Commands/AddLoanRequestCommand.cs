using AutoMapper;
using BankTest.Context;
using BankTest.DTO.LoanDto;
using BankTest.DTO.WalletDto;
using BankTest.Models;
using MediatR;

namespace BankTest.Features.Commands
{
	public class AddLoanRequestCommandHandler : IRequestHandler<AddLoanRequestDto, string>
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddLoanRequestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<string> Handle(AddLoanRequestDto addLoanRequestDto, CancellationToken cancellationToken)
		{
			var user = _unitOfWork.UserRepository.Get(where: (a => a.UserName == addLoanRequestDto.UserName)).FirstOrDefault();
			if (user == null || user.Password != addLoanRequestDto.Password)
			{
				return ("نام کاربری یا رمزعبور شما اشتباه است ! ");
			}
			var wallet = _unitOfWork.WalletRepository.Get(where: (a => a.UserId == user.Id)).FirstOrDefault();
			if (wallet == null)
			{
				return ("متاسفانه هیچ کیف پولی به نام شما ثبت نگردیده است");
			}
			if (wallet.IsBlocked == true)
			{
				return ("متاسفانه حساب کاربری شما مسدود است");
			}
			if (wallet.UserBalance / 2 < addLoanRequestDto.LoanAmount)
			{
				return ("متاسفانه میانگین حساب شما به حد کافی نیست");
			}
			Loan loan = new Loan()
			{
				Id = Guid.NewGuid(),
				RequestAmount = addLoanRequestDto.LoanAmount,
				RequestDate = DateTime.Now,
				UserCredit = wallet.UserBalance,
				WalletId = wallet.Id
			};
			_unitOfWork.LoanRepository.Insert(loan);
			_unitOfWork.LoanRepository.Save();
			return loan.Id.ToString();
		}

		
	}
}
