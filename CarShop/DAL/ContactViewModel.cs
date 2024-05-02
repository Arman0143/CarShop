using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShop.DAL
{
    public class ContactViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        public string number { get; set; }
        [Required(ErrorMessage = "Services is Required")]
        public string service { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
    }
}