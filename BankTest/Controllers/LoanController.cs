using System.Data;
using AutoMapper;
using BankTest.Context;
using BankTest.DTO.BalanceDto;
using BankTest.DTO.LoanDto;
using BankTest.DTO.UserDto;
using BankTest.Features.Queries;
using BankTest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static StackExchange.Redis.Role;

namespace BankTest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LoanController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;
		public LoanController(IUnitOfWork unitOfWork,IMapper mapper, IMediator mediator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> LoanRequest([FromQuery] AddLoanRequestDto addLoanRequestDto)
		{
			var result = await _mediator.Send(addLoanRequestDto);
			return Ok(result);
			//var user = _unitOfWork.UserRepository.Get(where: (a => a.UserName == addLoanRequestDto.UserName)).FirstOrDefault();
			//if (user == null || user.Password != addLoanRequestDto.Password)
			//{
			//	return BadRequest("نام کاربری یا رمزعبور شما اشتباه است ! ");
			//}
			//var wallet = _unitOfWork.WalletRepository.Get(where: (a => a.UserId == user.Id)).FirstOrDefault();
			//if (wallet == null)
			//{
			//	return BadRequest("متاسفانه هیچ کیف پولی به نام شما ثبت نگردیده است");
			//}
			//if (wallet.IsBlocked == true)
			//{
			//	return BadRequest("متاسفانه حساب کاربری شما مسدود است");
			//}
			//if (wallet.UserBalance/2 < addLoanRequestDto.LoanAmount)
			//{
			//	return BadRequest("متاسفانه میانگین حساب شما به حد کافی نیست");
			//}
			//Loan loan = new Loan()
			//{
			//	Id = Guid.NewGuid(),
			//	RequestAmount = addLoanRequestDto.LoanAmount,
			//	RequestDate = DateTime.Now,
			//	UserCredit = wallet.UserBalance,
			//	WalletId = wallet.Id
			//};
			//_unitOfWork.LoanRepository.Insert(loan);
			//_unitOfWork.LoanRepository.Save();
			//return Ok(loan.Id);

		}
		[HttpGet]
		public async Task<IActionResult> GetLoanRequestsAsync()
		{
			GetAllLoansDto getAllLoansDto =new GetAllLoansDto();
			var result = await _mediator.Send(getAllLoansDto);
			if (result == null)
			{
				return BadRequest("هیچ درخواست وامی ثبت نشده است");
			}
			return Ok(result);

			//List<Loan> loans = (List<Loan>) _unitOfWork.LoanRepository.Get();

			//if (loans == null)
			//{
			//	return BadRequest("هیچ درخواست وامی ثبت نشده است");
			//}
			//List<GetLoanRequestsDto> loanRequestsDto = new List<GetLoanRequestsDto>();
			//loanRequestsDto = _mapper.Map<List<GetLoanRequestsDto>>(loans);

			//return Ok(loanRequestsDto);
		}
	}
}
