using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BankTest.Models
{
	public class User
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		[MaxLength(100)]
		[MinLength(2)]
		public string FirstName { get; set; }
		[Required]
		[MaxLength(150)]
		[MinLength(2)]
		public string LastName { get; set; }
		[Required]
		[MaxLength(100)]
		[MinLength(4)]
		public string UserName { get; set; }
		[Required]
		[MaxLength(100)]
		[MinLength(5)]
		public string Password { get; set; }

	}
}
