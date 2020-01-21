using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Vektorel.EMarket.MVC.UI.Models.Validators
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        //+90(123)4567889
        //+1(123)4567889
        //+123(123)4567889
        protected readonly Regex PhoneRegex = new Regex(@"[+](?:\b|-)([1-9]{1,3}[0]?|999)[(][1-9][0-9]{2}[)][0-9]{7}\b");



        //+90(123)4567889
        //0090(123)4567889
        //+1(123)4567889
        //001(123)4567889
        //+123(123)4567889
        //00123(123)4567889
        protected readonly Regex altPhoneRegex = new Regex(@"^(?:(?:00|\+)\d{2}|0)[(][1-9](?:\d{2})[)](?:\d{7})");


        //001 123 456 78 89
        //+123 123 456 78 89
        protected readonly Regex PhoneWithSpaces = new Regex(@"^(?:(?:00|\+)\d{2}|0)[ ][1-9](?:\d{2})[ ](?:\d{3})[ ](?:\d{2})[ ](?:\d{2})");



        //8-14 karakter
        //En az 1 karakter büyük harf
        //En az 1 karakter küçük harf
        //En az 2 sayı
        //Ve 1 özel karakter [._!?@#$&*]
        protected readonly Regex PasswordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[_!?@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z]).{8,14}$");


        protected bool TwoDigitsMust(string password)
        {
            return Regex.IsMatch(password, ".*[0-9].*[0-9]");
        }
        protected bool MustContain1UppercaseCharacters(string password)
        {
            return Regex.IsMatch(password, ".*[A-Z]");
        }
        protected bool MustContain1LowercaseCharacters(string password)
        {
            return Regex.IsMatch(password, ".*[a-z]");
        }
        protected bool SpecialCharactersMust(string password)
        {
            return Regex.IsMatch(password, ".*[_!?@#$&*]");
        }
        protected bool EightToTenCharachterLengthMust(string password)
        {
            return Regex.IsMatch(password, ".{8,14}");
        }
    }
}