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
                .WithMessage("Nome é obrigatório!")
                .NotNull()
                .WithMessage("Nome é obrigatório!");

            RuleFor(x => x.Manager)
                .NotEmpty()
                .WithMessage("Manager é obrigatório!")
                .NotNull()
                .WithMessage("Manager é obrigatório!");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description é obrigatório!")
                .NotNull()
                .WithMessage("Description é obrigatório!");
        }
    }
}
