using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerUI.Validators
{
  public  class TournamentValidator : AbstractValidator<TournamentModel>
    {
        public TournamentValidator()
        {
            RuleFor(t => t.TournamentName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(" {PropertyName} must not be empty")
                .Length(2, 200).WithMessage(" {PropertyName} must be between 2-200 carecters")
                .Must(BeValideName).WithMessage(" {PropertyName} countines invalid carecters ");

            RuleFor(t => t.EnterdTeams)
           .Cascade(CascadeMode.Stop)
           .NotEmpty().WithMessage("  teams/players cannot be empty") 
           .Must(MinNum).WithMessage(" Tournaments needs a minimum of 2 teams/players");                
        }

        protected bool BeValideName(string str)
        {
          str =  str.Replace("-", "");
          str = str.Replace(" ", "");
          return str.All(char.IsLetter);
        }

        protected bool MinNum(List<TeamModel> teams)
        {
            if (teams.Count<2)
            {
                return false;
            }
            return true;
        }

    }
}
