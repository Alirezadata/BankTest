using System.ComponentModel.DataAnnotations;

namespace BankTest.DTO.WalletDto
{
	public class GetWalletInfo
	{
		[Required(ErrorMessage = "لطفا شناسه کیف پول را وارد کنید")]
		public Guid WalletId {  get; set; }
		[Required(ErrorMessage = "لطفا نام کاربر را وارد کنید")]
		[MaxLength(100, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
		[MinLength(2, ErrorMessage = "باید حداقل 2 کاراکتر وارد شود")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "لطفا نام خانوادگی کاربر را وارد کنید")]
		[MaxLength(150, ErrorMessage = "حداکثر 150 کاراکتر مجاز می باشد")]
		[MinLength(2)]
		public string LastName { get; set; }
		[Required(ErrorMessage = "لطفا موجودی کاربر را وارد کنید")]
		public double UserBalance { get; set; }
	}
}
