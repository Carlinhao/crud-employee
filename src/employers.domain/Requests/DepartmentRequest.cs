using FluentValidation;
using System.Text.Json.Serialization;

namespace employers.domain.Requests
{
    public class DepartmentRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("manager")]
        public int Manager { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class DepartmentRequestValidator : AbstractValidator<DepartmentRequest>
    {
        public DepartmentRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .NotNull()
                .WithMessage("Name is required."); 

            RuleFor(x => x.Manager)
                .NotEmpty()
                .WithMessage("Manager is required.")
                .NotNull()
                .WithMessage("Manager is required.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .NotNull()
                .WithMessage("Description is required.");
        }
    }
}
