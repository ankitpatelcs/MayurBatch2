using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JsAndValidations.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="First Name is Required.")]
        [RegularExpression("[A-Za-z]+",ErrorMessage ="Only alphabets.!")]
        [Display(Name ="First Name")]
        public string fname { get; set; }

        [Required]
        [RegularExpression(@"[9876]\d{9}",ErrorMessage ="Invalid mobile no.")]
        public string mobile { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email.")]
        public string email { get; set; }
        
        [Required]
        [RegularExpression("^(?=.*\\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[a-zA-Z!#$%&? \"])[a-zA-Z0-9!#$%&?]{8,20}$",ErrorMessage ="Password is weak.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="passwords do not match.")]
        public string cnfpassword { get; set; }
    }
}