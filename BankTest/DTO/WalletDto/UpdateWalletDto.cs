using System.ComponentModel.DataAnnotations;

namespace BankTest.DTO.WalletDto
{
	public class UpdateWalletDto
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public Guid UserId { get; set; }
		[Required]
		public double UserBalance { get; set; }
		[Required]
		public bool IsBlocked { get; set; }
	}
}
