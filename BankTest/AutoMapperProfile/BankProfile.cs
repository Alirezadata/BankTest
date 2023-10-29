using AutoMapper;
using BankTest.DTO.LoanDto;
using BankTest.DTO.TransferMoneyDto;
using BankTest.DTO.UserDto;
using BankTest.Models;

namespace BankTest.AutoMapperProfile
{
	public class BankProfile : Profile
	{
		public BankProfile()
		{
			CreateMap<AddUserDto, User>();
			CreateMap<AddTransferMoneyDto, Wallet>();
			CreateMap<Loan, GetLoanRequestsDto>().ReverseMap();
		}
	}
}
