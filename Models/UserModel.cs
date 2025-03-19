using SMS.Web.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SMS.Web.Models
{
    public class UserModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password Should be Minimum 6 Characters")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$",
            ErrorMessage = "Password must be alphanumeric with at least one special character.")]
        public string Password { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        public DateTime? UpdatedOn { get; set; }

        [Display(Name = "Deleted")]
        public bool? IsDeleted { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            using (var context = new SMSEntity())
            {
                var existingUser = context.TblUsers.FirstOrDefault(u => u.Email == Email);
                if (existingUser != null && existingUser.Id != Id) // Exclude current user if editing
                {
                    yield return new ValidationResult("Email already exists.", new[] { nameof(Email) });
                }
            }
        }
    }
}
