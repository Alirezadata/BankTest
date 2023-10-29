using AutoMapper;
using BankTest.Context;
using BankTest.DTO.LoanDto;
using BankTest.DTO.UserDto;
using BankTest.DTO.WalletDto;
using BankTest.Features.Queries;
using BankTest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BankTest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WalletController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMediator _mediator;
		public WalletController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromQuery] AddWalletDto addWalletDto)
		{
			var result = await _mediator.Send(addWalletDto);
			return Ok(result);
			//Wallet wallet = new Wallet();
			//var result = _unitOfWork.UserRepository.Get(where: (a => a.UserName == addWalletDto.UserName)).FirstOrDefault();
			//bool noWallet = _unitOfWork.WalletRepository.Get(where: (a => a.UserId == result.Id)).IsNullOrEmpty();
			//if (result == null || result.Password != addWalletDto.Password)
			//{
			//	return BadRequest("نام کاربری یا رمزعبور شما اشتباه است ! ");
			//}
			//else if (noWallet == false)
			//{
			//	return BadRequest("یک کیف پول به این حساب کاربری اختصاص دارد !");
			//}
			//wallet.Id = Guid.NewGuid();
			//wallet.UserId = result.Id;
			//wallet.UserBalance = 30000;
			//wallet.IsBlocked = false;
			//_unitOfWork.WalletRepository.Insert(wallet);
			//_unitOfWork.WalletRepository.Save();
			//return Ok();
		}
		[HttpGet]
		public async Task<IActionResult> GetAllWallets()
		{

			//List<Wallet> wallets = (List<Wallet>)_unitOfWork.WalletRepository.Get();
			//List<User> Users = (List<User>)_unitOfWork.UserRepository.Get();


			//if (wallets == null)
			//{
			//	return BadRequest("هیچ کیف پولی ثبت نشده است");
			//}
			//var query = (from w in wallets
			//			 join u in Users on w.UserId equals u.Id
			//			 select new GetWalletInfo//anonymous type
			//			 {
			//				 WalletId = w.Id,
			//				 FirstName = u.FirstName,
			//				 LastName = u.LastName,
			//				 UserBalance = w.UserBalance,

			//			 });
			//List<GetWalletInfo> walletsInfo = query.ToList();
			//return Ok(walletsInfo);

			GetAllWalletsDto getAllWalletsDto = new GetAllWalletsDto();
			var result = await _mediator.Send(getAllWalletsDto);
			return Ok(result);
		}
	}
}
