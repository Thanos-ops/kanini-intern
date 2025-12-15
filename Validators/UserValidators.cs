using FluentValidation;
using Foodapi.DTOs;

namespace Foodapi.Validators;

public class UserProfileDtoValidator : AbstractValidator<UserProfileDto>
{
    public UserProfileDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(255);
        RuleFor(x => x.Mobile).NotEmpty().Matches(@"^\d{10}$").WithMessage("Mobile must be 10 digits");
    }
}

public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordDtoValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty();
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6);
    }
}

public class AddressDtoValidator : AbstractValidator<AddressDto>
{
    public AddressDtoValidator()
    {
        RuleFor(x => x.Address).NotEmpty().MaximumLength(300);
        RuleFor(x => x.CityId).GreaterThan(0).WithMessage("City must be selected");
        RuleFor(x => x.StateId).GreaterThan(0).WithMessage("State must be selected");
    }
}