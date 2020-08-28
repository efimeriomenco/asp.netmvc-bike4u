using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeShop.Models;
using FluentValidation;

namespace BikeShop.ViewModel
{
    public class ContactsViewModel
    {
        public List<Contact> AllContactses { get; set; }
        public FeedbackViewModel Form { get; set; }

    }

    public class ContactsViewModelValidator : AbstractValidator<ContactsViewModel>
    {
        public ContactsViewModelValidator()
        {
            
            RuleFor(x => x.Form.firstName).NotEmpty()
                .WithMessage("*Please enter your first name.")
                .MinimumLength(3).WithMessage("*Minimum length of 8 characters are allowed")
                .MaximumLength(50).WithMessage("*Maximum length of 50 charaters is allowed");
            RuleFor(x => x.Form.lastName).NotEmpty()
                .WithMessage("*Please enter your last name.")
                .MinimumLength(8).WithMessage("*Minimum length of 8 characters are allowed")
                .MaximumLength(50).WithMessage("*Maximum length of 50 charaters is allowed");
            RuleFor(x => x.Form.email).EmailAddress()
                .WithMessage("Please enter your E-Mail.");

            RuleFor(x => x.Form.selectedItem).NotEmpty();
                
            RuleFor(x => x.Form.message).NotEmpty()
                .WithMessage("*Please enter your message")
                .MaximumLength(300).WithMessage("*Maximum length of 300 charaters is allowed");
        }
    }
}
