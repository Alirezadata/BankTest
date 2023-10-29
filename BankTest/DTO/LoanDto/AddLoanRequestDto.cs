using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BankTest.DTO.LoanDto
{
	public class AddLoanRequestDto : IRequest<string>
	{
		[Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
		[MaxLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
		[MinLength(4, ErrorMessage = "باید حداقل 4 کاراکتر وارد شود")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "لطفا رمزعبور را وارد کنید")]
		[MaxLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
		[MinLength(5, ErrorMessage = "باید حداقل 5 کاراکتر وارد شود")]
		public string Password { get; set; }
		[Required(ErrorMessage = "لطفا مبلغ درخواستی برای وام را وارد کنید")]
		public double LoanAmount {  get; set; }
	}
}
