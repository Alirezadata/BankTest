using AutoMapper;
using BankTest.Context;
using BankTest.DTO.UserDto;
using BankTest.DTO.WalletDto;
using BankTest.Models;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace BankTest.Features.Commands
{
    public class CreateWalletCommandHandler : IRequestHandler<AddWalletDto, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateWalletCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(AddWalletDto addWalletDto, CancellationToken cancellationToken)
        {
            Wallet wallet = new Wallet();
            var result = _unitOfWork.UserRepository.Get(where: a => a.UserName == addWalletDto.UserName).FirstOrDefault();
            bool noWallet = _unitOfWork.WalletRepository.Get(where: a => a.UserId == result.Id).IsNullOrEmpty();
            if (result == null || result.Password != addWalletDto.Password)
            {
                return "نام کاربری یا رمزعبور شما اشتباه است ! ";
            }
            else if (noWallet == false)
            {
                return "یک کیف پول به این حساب کاربری اختصاص دارد !";
            }
            wallet.Id = Guid.NewGuid();
            wallet.UserId = result.Id;
            wallet.UserBalance = 30000;
            wallet.IsBlocked = false;
            _unitOfWork.WalletRepository.Insert(wallet);
            _unitOfWork.WalletRepository.Save();

            return "کیف پول با موفقیت ثبت گردید";
        }
    }
}
