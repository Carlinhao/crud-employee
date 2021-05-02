using FluentValidation;
using System.Text.Json.Serialization;

namespace employers.domain.Requests
{
    public class EmployerRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id_department")]
        public int IdDepartment { get; set; }

        [JsonPropertyName("id_occupation")]
        public int IdOccupation { get; set; }

        [JsonPropertyName("gender")]
        public char Gender { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }

    public class EmployerRequestValidator : AbstractValidator<EmployerRequest>
    {
        public EmployerRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .NotNull()
                .WithMessage("Name is required");

            RuleFor(x => x.IdDepartment)
                .NotEmpty()
                .WithMessage("Id Department is required")
                .NotNull()
                .WithMessage("Id Department is required");

            RuleFor(x => x.IdOccupation)
                .NotEmpty()
                .WithMessage("Id Occupation is required")
                .NotNull()
                .WithMessage("Id Occupation is required");

            RuleFor(x => x.Gender)
                .NotEmpty()
                    .WithMessage("Gender is required")
                .NotNull()
                    .WithMessage("Gender is required")
                .Must(x => x.Equals('F') || x.Equals('M') || x.Equals('O'))
                    .WithMessage("Options: Female 'F', Male 'M' or Other 'O'");

            RuleFor(x => x.Active)
                .NotEmpty()
                .WithMessage("Active is required");
        }
    }
}
