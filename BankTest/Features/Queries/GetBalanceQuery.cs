using AutoMapper;
using BankTest.Context;
using BankTest.DTO.BalanceDto;
using BankTest.DTO.LoanDto;
using BankTest.Models;
using MediatR;

namespace BankTest.Features.Queries
{
	public class GetBalanceQuery
	{
	}
	public class GetBalanceQueryHandler : IRequestHandler<GetBalanceDto, string>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public GetBalanceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<string> Handle(GetBalanceDto getBalanceDto, CancellationToken cancellationToken)
		{
			var user = _unitOfWork.UserRepository.Get(where: (a => a.UserName == getBalanceDto.UserName)).FirstOrDefault();

			if (user == null || user.Password != getBalanceDto.Password)
			{
				return ("نام کاربری یا رمزعبور شما اشتباه است ! ");
			}
			var wallet = _unitOfWork.WalletRepository.Get(where: (a => a.UserId == user.Id)).FirstOrDefault();
			if (wallet == null)
			{
				return ("متاسفانه هیچ کیف پولی به نام شما ثبت نگردیده است");
			}

			return wallet.UserBalance.ToString();
		}
	}
	
}
