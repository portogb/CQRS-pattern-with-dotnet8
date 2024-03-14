using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cities.Application.Command.City.CreateCity
{
    public sealed class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Must(ValidName)
                .WithMessage("Name is invalid");

            RuleFor(x => x.State)
                .NotEmpty()
                .NotNull()
                .Must(ValidName)
                .WithMessage("State is invalid");
        }

        public static bool ValidName(string name)
        {
            Regex regex = new("^[a-zA-Z\\u0080-\\u024F]+(?:([\\ \\-\\']|(\\.\\ ))[a-zA-Z\\u0080-\\u024F]+)*$");

            return regex.IsMatch(name);
        }
    }
}
