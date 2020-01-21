using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using FluentValidation;
using FluentValidation.Results;
using Vektorel.EMarket.MVC.UI.Models.ViewModels;

namespace Vektorel.EMarket.MVC.UI.Models.Validators
{
    public class LoginValidator : BaseValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("You have to enter email address")
                .MinimumLength(10)
                .WithMessage("You have to enter a value at least 10 characters")
                .EmailAddress()
                .WithMessage("You must enter a valid email address.");



            //Custom ve Must metodu için birer örnek yaptım size
            //Bu her 2 yöntem de sadece server-side validation için geçerli, eğer ki client-side bir validation yapmak söz konusu ve şart ise o zaman tek bir pattern ile matches metodunu kullanarak bir regex göndermek ya da fluent validation varsayılan metodlarını kullanmak uygun olur. Bizim senaryomuzda login işlemi 

            //Custom metodu 2 parametre alan bir action'ı parametre olarak alır. bunun birincisi custom metodun bağlandığı propertynin kendisi diğeri ise bu property yöneten validasyonun contexti dolayısı ile bu propertynin durumuna bağlı olarak bu contexte AddFailure metodu ile bir hata eklemek mümkün

            //Must metodu ise bağlandığı property türünde bir parametre alan ve sonuç olarak boolean dönen bir action'ı parametre olarak alır, metodu başka bir yerde tanımlamak da zaten bildiğiniz gibi mümkün ben 2. örnekte metodu BaseValidator sınıfında tanımlayıp burada sadece metodu gönderdim. Diğer must örneğinde ise metoda parametreyi anonim bir metod olarak gönderdim
            
            //Dikkat ettiğiniz üzere custom metodunu eklerken withmessage uygulamadım cunku failure eklediğimiz yerde mesajı da belirtiyoruz.


            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("You have to enter your password.")
                .MinimumLength(8)
                .WithMessage("Between 8-14 characters")
                .MaximumLength(14)
                .WithMessage("Between 8-14 characters")
                .Custom((password, ctx) =>
                {
                    string message = String.Empty;
                    if (!Regex.IsMatch(password, ".*[0-9].*[0-9]"))
                    {
                        message = "At least 2 digits";
                    }
                    if (!Regex.IsMatch(password, ".*[A-Z]"))
                    {
                        message = "At least 1 uppercase character";
                    }
                    if (!Regex.IsMatch(password, ".*[a-z]"))
                    {
                        message = "At least 1 lowercase character";
                    }
                    if (!Regex.IsMatch(password, ".*[_!?@#$&*]"))
                    {
                        message = "At least 1 special character";
                    }
                    //if (!Regex.IsMatch(password, ".*[_!?@#$&*].*[_!?@#$&*]"))
                    //{
                    //    message = "At least 2 special character";
                    //}

                    //Eğer yukarıdaki koşullardan biri gerçekleşmiş ise bu durumda contexte bir hata ekliyorum. Mesaj olarak da belirlenen son mesajı yazıyorum.
                    if (!string.IsNullOrEmpty(message))
                    {
                        ctx.AddFailure(new ValidationFailure("Password", message));
                    }
                })
                //1. Must örneği
                .Must(password =>
                {
                    return true;
                })
                .WithMessage("No feature")
                //2. Must örneği
                .Must(TwoDigitsMust)
                .WithMessage("At least 2 digits");





            //.MinimumLength(8)
            //.WithMessage("You have to enter a password 8-14 characters")
            //.MaximumLength(14)
            //.WithMessage("You have to enter a password 8-14 characters");
            //.Matches(PasswordRegex)
            //.WithMessage("Your password must contain at least 1 uppercase, 1 lowercase , 2 numbers and 1 special characters and it must be 8-14 length.");




        }
    }
}