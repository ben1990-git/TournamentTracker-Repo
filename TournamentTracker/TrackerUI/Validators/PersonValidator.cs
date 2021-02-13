using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerUI.Validators
{
   public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .Must(BeValideName).WithMessage("{PropertyName} is not valid");

            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .Must(BeValideName).WithMessage("{PropertyName} is not valid");

            RuleFor(p => p.EmailAddress)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().NotEmpty().WithMessage("{PropertyName} must not be empty")
                .EmailAddress().NotEmpty().WithMessage("{PropertyName} must not be empty");



        }

        protected bool BeValideName(string str)
        {
            str = str.Replace("-", "");
            str = str.Replace(" ", "");
            return str.All(char.IsLetter);
        }
    }
}
