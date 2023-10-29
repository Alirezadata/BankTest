using AutoMapper;
using BankTest.Context;
using BankTest.DTO.WalletDto;
using BankTest.Models;
using MediatR;

namespace BankTest.Features.Queries
{
	public class GetAllWalletsQueryHandler : IRequestHandler<GetAllWalletsDto, List<GetWalletInfo>>
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetAllWalletsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<List<GetWalletInfo>> Handle(GetAllWalletsDto getAllWalletsDto, CancellationToken cancellationToken)
		{
			List<Wallet> wallets = (List<Wallet>)_unitOfWork.WalletRepository.Get();
			List<User> Users = (List<User>)_unitOfWork.UserRepository.Get();


			if (wallets == null)
			{
				return null;
			}
			var query = (from w in wallets
						 join u in Users on w.UserId equals u.Id
						 select new GetWalletInfo//anonymous type
						 {
							 WalletId = w.Id,
							 FirstName = u.FirstName,
							 LastName = u.LastName,
							 UserBalance = w.UserBalance,

						 });

			List<GetWalletInfo> walletsInfo = query.ToList();
			return walletsInfo;
		}
	}
	public class GetAllWalletsDto : IRequest<List<GetWalletInfo>>
	{

	}
}
