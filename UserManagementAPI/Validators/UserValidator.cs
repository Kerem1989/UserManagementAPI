using FluentValidation;
using UserManagementAPI.Models;

namespace UserManagementAPI.Validators ;

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.");
        }
    }