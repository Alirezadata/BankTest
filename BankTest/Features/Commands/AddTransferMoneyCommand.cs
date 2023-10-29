using AutoMapper;
using bankTest.Services;
using BankTest.Context;
using BankTest.DTO.TransferMoneyDto;
using BankTest.DTO.UserDto;
using BankTest.Models;
using MediatR;

namespace BankTest.Features.Commands
{

    public class AddTransferMoneyCommand : IRequestHandler<AddTransferMoneyDto, string>
    {
        private readonly IRedisService _redisService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddTransferMoneyCommand(IUnitOfWork unitOfWork, IMapper mapper, IRedisService redisService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redisService = redisService;
        }
        public async Task<string> Handle(AddTransferMoneyDto addTransferMoneyDto, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.UserRepository.Get(where: a => a.UserName == addTransferMoneyDto.UserName).FirstOrDefault();
            var ErrorNumCache = _redisService.GetCachedData<int>(result.Id.ToString());

            if (result == null || result.Password != addTransferMoneyDto.Password)
            {
                return "نام کاربری یا رمزعبور شما اشتباه است ! ";
            }
            var originWallet = _unitOfWork.WalletRepository.Get(where: a => a.Id == addTransferMoneyDto.OriginWalletId).FirstOrDefault();
            if (originWallet == null)
            {
                return "آدرس کیف پول مبدا به درستی وارد نشده است !";
            }
            if (originWallet.UserId != result.Id)
            {
                return "آدرس کیف پول مبدا به شما تعلق ندارد";
            }
            var destinationWallet = _unitOfWork.WalletRepository.Get(where: a => a.Id == addTransferMoneyDto.DestinationWalletId).FirstOrDefault();
            if (destinationWallet == null)
            {
                return "آدرس کیف پول مقصد به درستی وارد نشده است !";
            }
            if (originWallet.IsBlocked == true)
            {
                return "حساب مبدا شما مسدود می باشد!شما قادر به انتقال وجه نمی باشید";
            }
            if (destinationWallet.IsBlocked == true)
            {
                if (addTransferMoneyDto.Amount < 100000)
                {

                    return "حساب مقصد شما مسدود می باشد!شما قادر به انتقال وجه نمی باشید";
                }
                _redisService.RemoveData(result.Id.ToString());
                destinationWallet.IsBlocked = false;
            }

            if (ErrorNumCache >= 3)
            {
                if (originWallet.IsBlocked == false)
                {
                    originWallet.IsBlocked = true;
                    _unitOfWork.WalletRepository.Update(originWallet);
                    _unitOfWork.WalletRepository.Save();
                    return "شما بیش از سه بار در 24 ساعت گذشته تلاش به انتقال حساب با عدم موجودی داشته اید!حساب شما مسدود گردیده است";
                }

            }
            if (originWallet == destinationWallet)
            {
                return " شما نمی توانید حساب مبدا و مقصد را یکی در نظر بگیرید! این منطقی نیست !!! ";
            }
            if (originWallet.UserBalance < addTransferMoneyDto.Amount)
            {
                ErrorNumCache = _redisService.GetCachedData<int>(result.Id.ToString());
                if (ErrorNumCache == null || ErrorNumCache == default)
                {
                    _redisService.SetCachedData(result.Id.ToString(), 1, TimeSpan.FromHours(24));
                }
                else
                {
                    _redisService.RemoveData(result.Id.ToString());
                    _redisService.SetCachedData(result.Id.ToString(), ErrorNumCache + 1, TimeSpan.FromHours(24));
                }
                return "موجودی شما کافی نمی باشد";
            }
            originWallet.UserBalance = originWallet.UserBalance - addTransferMoneyDto.Amount;
            destinationWallet.UserBalance = destinationWallet.UserBalance + addTransferMoneyDto.Amount;

            _unitOfWork.WalletRepository.Update(originWallet);
            _unitOfWork.WalletRepository.Update(destinationWallet);
            _unitOfWork.WalletRepository.Save();

            return "تراکنش با موفقت انجام شد";
        }
    }
}
