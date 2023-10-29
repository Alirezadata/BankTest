using AutoMapper;
using bankTest.Services;
using BankTest.Context;
using BankTest.DTO.TransferMoneyDto;
using BankTest.DTO.UserDto;
using BankTest.DTO.WalletDto;
using BankTest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace BankTest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TransferMoneyController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRedisService _redisService;
		private readonly IMediator _mediator;
		public TransferMoneyController(IUnitOfWork unitOfWork, IMapper mapper,IRedisService redisService,IMediator mediator)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_redisService = redisService;
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> AddTransferMoneyAsync([FromQuery] AddTransferMoneyDto addTransferMoneyDto)
		{

			var result = await _mediator.Send(addTransferMoneyDto);
			return Ok(result);
			//var result = _unitOfWork.UserRepository.Get(where: (a => a.UserName == addTransferMoneyDto.UserName)).FirstOrDefault();
			//var ErrorNumCache = _redisService.GetCachedData<int>(result.Id.ToString());

			//if (result == null || result.Password != addTransferMoneyDto.Password)
			//{
			//	return BadRequest("نام کاربری یا رمزعبور شما اشتباه است ! ");
			//}
			//var originWallet = _unitOfWork.WalletRepository.Get(where: (a => a.Id == addTransferMoneyDto.OriginWalletId)).FirstOrDefault();
			//if (originWallet == null)
			//{
			//	return BadRequest("آدرس کیف پول مبدا به درستی وارد نشده است !");
			//}
			//if(originWallet.UserId != result.Id)
			//{
			//	return BadRequest("آدرس کیف پول مبدا به شما تعلق ندارد");
			//}
			//var destinationWallet = _unitOfWork.WalletRepository.Get(where: (a => a.Id == addTransferMoneyDto.DestinationWalletId)).FirstOrDefault();
			//if (destinationWallet == null)
			//{
			//	return BadRequest("آدرس کیف پول مقصد به درستی وارد نشده است !");
			//}
			//if(originWallet.IsBlocked==true) 
			//{
			//	return BadRequest("حساب مبدا شما مسدود می باشد!شما قادر به انتقال وجه نمی باشید");
			//}
			//if (destinationWallet.IsBlocked == true)
			//{
			//	if(addTransferMoneyDto.Amount < 100000)
			//	{

			//		return BadRequest("حساب مقصد شما مسدود می باشد!شما قادر به انتقال وجه نمی باشید");
			//	}
			//	_redisService.RemoveData(result.Id.ToString());
			//	destinationWallet.IsBlocked = false; 
			//}

			//if (ErrorNumCache > 3)
			//{
			//	if (originWallet.IsBlocked == false)
			//	{
			//		originWallet.IsBlocked = true;
			//		return BadRequest("شما بیش از سه بار در 24 ساعت گذشته تلاش به انتقال حساب با عدم موجودی داشته اید!حساب شما مسدود گردیده است");
			//	}

			//}
			//if (originWallet == destinationWallet)
			//{
			//	return BadRequest(" شما نمی توانید حساب مبدا و مقصد را یکی در نظر بگیرید! این منطقی نیست !!! ");
			//}
			//if(originWallet.UserBalance < addTransferMoneyDto.Amount)
			//{
			//	ErrorNumCache = _redisService.GetCachedData<int>(result.Id.ToString());
			//	if (ErrorNumCache == null || ErrorNumCache == default)
			//	{
			//		_redisService.SetCachedData(result.Id.ToString(), 1, TimeSpan.FromHours(24));
			//	}
			//	else 
			//	{
			//		_redisService.RemoveData(result.Id.ToString());
			//		_redisService.SetCachedData(result.Id.ToString(), ErrorNumCache + 1, TimeSpan.FromHours(24));
			//	}
			//	return BadRequest("موجودی شما کافی نمی باشد");
			//}
			//originWallet.UserBalance = originWallet.UserBalance - addTransferMoneyDto.Amount;
			//destinationWallet.UserBalance = destinationWallet.UserBalance + addTransferMoneyDto.Amount;

			//_unitOfWork.WalletRepository.Update(originWallet);
			//_unitOfWork.WalletRepository.Update(destinationWallet);
			//_unitOfWork.WalletRepository.Save();

			//return Ok("تراکنش با موفقت انجام شد");


		}

	}
}
