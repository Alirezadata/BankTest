using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BankTest.DTO.TransferMoneyDto
{
	public class AddTransferMoneyDto : IRequest<string>
	{
		[Required(ErrorMessage = "لطفا شناسه کیف پول مبدا را وارد کنید")]
		public Guid OriginWalletId { get; set; }
		[Required(ErrorMessage = "لطفا شناسه کیف پول مقصد را وارد کنید")]
		public Guid DestinationWalletId { get; set;}
		[Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
		[MaxLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
		[MinLength(3, ErrorMessage = "باید حداقل 3 کاراکتر وارد شود")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "لطفا رمزعبور را وارد کنید")]
		[MaxLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
		[MinLength(5, ErrorMessage = "باید حداقل 5 کاراکتر وارد شود")]
		public string Password { get; set; }
		[Required(ErrorMessage = "لطفا مبلغ انتقال وجه را وارد کنید")]
		public double Amount { get; set; }

	}
}
