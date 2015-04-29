using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Transit.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Transit.ViewModels
{
    public class AddUserViewModel
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Phone")]
		[Phone]
        public virtual string PhoneNumber { get; set; }

        [DisplayName("Email Address")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,5}", ErrorMessage = "Valid email address format required.")]
        public virtual string Email { get; set; }
    }

    public class UserViewModel
    {
        //fake password to be used to send out instead of the real password
        //also to detect when password doesn't need to be updated/wasn't changed
        public const string maskedPassword = "******************************";  //thirty asterisks
        
        [Key]
        //88f8abed-d918-4c6c-b3a4-422bf8e99d9a
        [RegularExpression(@"[a-f\d]{8}-([a-f\d]{4}-){3}[a-f\d]{12}")]
        public virtual string Id { get; set; }


		[Required]
		[Display(Name = "Username")]
		public string UserName { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[DisplayName("Phone")]
		[Phone]
		public virtual string PhoneNumber { get; set; }

		[DisplayName("Email Address")]
		[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,5}", ErrorMessage = "Valid email address format required.")]
		public virtual string Email { get; set; }

        public virtual ICollection<IdentityUserRole> Roles { get; set; }
    }
}