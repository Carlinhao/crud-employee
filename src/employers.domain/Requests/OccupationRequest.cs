using System.Text.Json.Serialization;
using FluentValidation;

namespace employers.domain.Requests
{
    public class OccupationRequest
    {
        [JsonPropertyName("name_occupation")]
        public string NameOccupation { get; set; }

        [JsonPropertyName("level_occupation")]
        public string LevelOccupation { get; set; }
    }

    public class OccupationRequestValidator : AbstractValidator<OccupationRequest>
    {
        public OccupationRequestValidator()
        {
            RuleFor(x => x.NameOccupation)
                .NotEmpty()
                    .WithMessage("Occupation name is required")
                .NotNull()
                    .WithMessage("Occupation name is required");

            RuleFor(x => x.LevelOccupation)
                .NotEmpty()
                    .WithMessage("Occupation leve is required")
                .NotNull()
                    .WithMessage("Occupation leve is required");
        }
    }
}
