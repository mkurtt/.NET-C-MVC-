using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vektorel.EMarket.MVC.UI.Models.ViewModels;

namespace Vektorel.EMarket.MVC.UI.Models.Validators
{
    public class RegisterValidator : BaseValidator<RegisterModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("You have to enter email address")
                .MinimumLength(10)
                .WithMessage("You have to enter a value at least 10 characters")
                .EmailAddress()
                .WithMessage("You must enter a valid email address.");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("You have to enter your password.")
                .Matches(PasswordRegex)
                .WithMessage("Your password must contain at least 1 uppercase, 1 lowercase , 2 numbers and 1 special characters and it must be 8-14 length.");




            RuleFor(x => x.Password)
              .Equal(x => x.ConfirmPassword)
              .WithMessage("The password does not match")
              .When(x => !(string.IsNullOrWhiteSpace(x.Password) || string.IsNullOrWhiteSpace(x.ConfirmPassword)));
        }
    }
}