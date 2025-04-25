using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class Employees
    {
        public int EmpId { get; set; }
        [DisplayName("FirstName")]
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [DisplayName("LastName")]
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        //[DisplayName("Date of Birth")]
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(30)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string EmailId { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string ContactNo { get; set; }

        public string Address { get; set; } 
    }
}