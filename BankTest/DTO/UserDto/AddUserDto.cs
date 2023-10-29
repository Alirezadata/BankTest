using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankTest.DTO.UserDto
{
	public class AddUserDto : IRequest<string>
	{
		[Required(ErrorMessage = "لطفا نام کاربر را وارد کنید")]
		[MaxLength(100,ErrorMessage ="حداکثر 100 کاراکتر مجاز می باشد")]
		[MinLength(2, ErrorMessage = "باید حداقل 2 کاراکتر وارد شود")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "لطفا نام خانوادگی کاربر را وارد کنید")]
		[MaxLength(150, ErrorMessage = "حداکثر 150 کاراکتر مجاز می باشد")]
		[MinLength(2)]
		public string LastName { get; set; }
		[Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
		[MaxLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
		[MinLength(3, ErrorMessage = "باید حداقل 3 کاراکتر وارد شود")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "لطفا رمزعبور را وارد کنید")]
		[MaxLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
		[MinLength(5, ErrorMessage = "باید حداقل 5 کاراکتر وارد شود")]
		public string Password { get; set; }

	}
}
