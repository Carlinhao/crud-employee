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
                .WithMessage("Department is required")
                .NotNull()
                .WithMessage("Department is required");
        }
    }
}
