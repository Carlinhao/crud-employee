using FluentValidation;

namespace employers.domain.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                    .WithMessage("User name is required.")
                .NotNull()
                    .WithMessage("User name is required.");

            RuleFor(x => x.FullName)
                .NotEmpty()
                    .WithMessage("Complete name is required.")
                .NotNull()
                    .WithMessage("Complete name is required.");
            
            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("Password is required.")
                .NotNull()
                    .WithMessage("Password is required.");
        }
    }
}
