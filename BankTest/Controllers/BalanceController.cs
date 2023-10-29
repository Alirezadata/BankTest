using AutoMapper;
using BankTest.Context;
using BankTest.DTO.BalanceDto;
using BankTest.DTO.WalletDto;
using BankTest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankTest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BalanceController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMediator _mediator;
		public BalanceController(IUnitOfWork unitOfWork, IMediator mediator)
		{
			_mediator = mediator;
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task< IActionResult> Get([FromQuery] GetBalanceDto getBalanceDto)
		{
			var result = await _mediator.Send(getBalanceDto);
			return Ok(result);

			//var user = _unitOfWork.UserRepository.Get(where: (a => a.UserName == getBalanceDto.UserName)).FirstOrDefault();

			//if (user == null || user.Password != getBalanceDto.Password)
			//{
			//	return BadRequest("نام کاربری یا رمزعبور شما اشتباه است ! ");
			//}
			//var wallet = _unitOfWork.WalletRepository.Get(where: (a => a.UserId == user.Id)).FirstOrDefault();
			//if (wallet == null)
			//{
			//	return BadRequest("متاسفانه هیچ کیف پولی به نام شما ثبت نگردیده است");
			//}

			//return Ok(wallet.UserBalance);
		}

	}
}

