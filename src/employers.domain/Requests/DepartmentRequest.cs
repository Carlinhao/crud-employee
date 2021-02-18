using FluentValidation;
using System.Text.Json.Serialization;

namespace employers.domain.Requests
{
    public class DepartmentRequest
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }
    }

    public class DepartmentRequestValidator : AbstractValidator<DepartmentRequest>
    {
        public DepartmentRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório!")
                .NotNull()
                .WithMessage("Nome é obrigatório!");
        }
    }
}
