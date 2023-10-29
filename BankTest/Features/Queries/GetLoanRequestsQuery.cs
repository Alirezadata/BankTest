using AutoMapper;
using BankTest.Context;
using BankTest.DTO.LoanDto;
using BankTest.DTO.WalletDto;
using BankTest.Models;
using MediatR;

namespace BankTest.Features.Queries
{
	public class GetLoanRequestsQueryHandler : IRequestHandler<GetAllLoansDto, List<GetLoanRequestsDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public GetLoanRequestsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<List<GetLoanRequestsDto>> Handle(GetAllLoansDto getAllWalletsDto, CancellationToken cancellationToken)
		{
			List<Loan> loans = (List<Loan>)_unitOfWork.LoanRepository.Get();

			if (loans == null)
			{
				return null;
			}
			List<GetLoanRequestsDto> loanRequestsDto = new List<GetLoanRequestsDto>();
			loanRequestsDto = _mapper.Map<List<GetLoanRequestsDto>>(loans);

			return loanRequestsDto;
		}
	}
	public class GetAllLoansDto : IRequest<List<GetLoanRequestsDto>>
	{

	}
}
