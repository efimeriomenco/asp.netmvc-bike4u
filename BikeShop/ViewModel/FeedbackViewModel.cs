using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeShop.ViewModel
{
    public class FeedbackViewModel
    {
        [Required(ErrorMessage = "This field is required." +
                                 "Please enter your *first name.")]
        
        public string firstName { get; set; }
        [Required(ErrorMessage = "This field is required." +
                                 "Please enter your *last name.")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "This field is required." +
                                 "Please enter your *e-mail.")]
        public string email { get; set; }
        public string selectedItem { get; set; }
        public string message { get; set; }
        public SelectList selectList { get; set; }
    }

}
