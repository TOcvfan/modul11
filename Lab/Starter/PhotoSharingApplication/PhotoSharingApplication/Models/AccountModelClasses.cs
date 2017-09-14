using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel;

namespace PhotoSharingApplication.Models {
	public class AccountModelClasses {
		public class UsersContext : DbContext {

		}

		
	}
	public class login {
		[Required]
		[DisplayName("User Name")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Password")]
		public string Password { get; set; }

		[DisplayName("Remember Me?")]
		public bool RememberMe { get; set; }

	}

	public class Register {
		[Required]
		[DisplayName("User Name")]
		public string UserName { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be minimum {2} charaters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[DisplayName("Password")]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Confirm Password")]
		[Compare("Password", ErrorMessage = "Passwords does not match...")]
		public string ConfirmPassword { get; set; }
	}
}