using AutoMapper;
using BankTest.Context;
using BankTest.DTO.UserDto;
using BankTest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BankTest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserRegistrationController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMediator _mediator;
		public UserRegistrationController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> AddUsers( AddUserDto addUserDTO)
		{
			var result = await _mediator.Send(addUserDTO);
			//User user = new User();
			//bool result = _unitOfWork.UserRepository.Get(where: (a => a.UserName == addUserDTO.UserName)).IsNullOrEmpty();
			//if (result == false)
			//{
			//	return BadRequest("این نام کاربری موجود است! لطفا با نام کاربری دیگر ثبت نام کنید");
			//}
			//user = _mapper.Map<User>(addUserDTO);
			//user.Id = Guid.NewGuid();
			//_unitOfWork.UserRepository.Insert(user);
			//_unitOfWork.UserRepository.Save();

			return Ok(result);
		}
	}
}
