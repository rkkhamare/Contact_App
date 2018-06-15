using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evolent.Web.Models
{
    public class ContactDTO
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "FirstName sholud be Max 100")]
        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter LastName")]
        [MaxLength(100, ErrorMessage = "LastName sholud be Max 100")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EmailId is Required")]
        [MaxLength(200, ErrorMessage = "EmailId sholud be Max 200")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter PhoneNumber")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Contact")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}