﻿using System.ComponentModel.DataAnnotations;

namespace BankTest.Models
{
	public class Loan
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public Guid WalletId { get; set; }
		[Required]
		public DateTime RequestDate { get; set; }
		[Required]
		public double RequestAmount { get; set; }
		[Required]
		public double UserCredit {  get; set; }
	}
}
