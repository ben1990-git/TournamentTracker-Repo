using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerUI.Validators
{
    public class TeamValidator: AbstractValidator<TeamModel>
    {
        public TeamValidator()
        {
            RuleFor(tm => tm.TeamName).NotEmpty().WithMessage("{PropertyName} can not be empty");
            RuleFor(tm => tm.TeamMembers).NotEmpty().WithMessage("{PropertyName} nust have at least one member");
        }
    }
}
