using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Models
{
    public class RegistrationModel
    {
        private const string PassFormat = @"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{6,}";

        [Display(Name = "User name")]
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The user name must contain between 1 and 100 characters.")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The password must contain at least 6 characters.")]
        [RegularExpression(PassFormat, ErrorMessage = "The password must contain only latin letters, at least 1 character must be in upper and lower case, at least 1 character must be a number.")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string PasswordConfirm { get; set; }
    }
}