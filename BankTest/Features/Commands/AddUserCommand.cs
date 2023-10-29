using AutoMapper;
using BankTest.Context;
using BankTest.DTO.UserDto;
using BankTest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BankTest.Features.Commands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserDto, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(AddUserDto addUserDTO, CancellationToken cancellationToken)
        {
            User user = new User();
            bool result = _unitOfWork.UserRepository.Get(where: a => a.UserName == addUserDTO.UserName).IsNullOrEmpty();
            if (result == false)
            {
                return "این نام کاربری موجود است! لطفا با نام کاربری دیگر ثبت نام کنید";
            }
            user = _mapper.Map<User>(addUserDTO);
            user.Id = Guid.NewGuid();
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.UserRepository.Save();
            return "کاربر با موفقیت ثبت گردید";
        }
    }
}
