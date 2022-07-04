using System.Text.Json.Serialization;
using FluentValidation;

namespace employers.domain.Requests
{
    public class OccupationUpdateRequest
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name_occupation")]
        public string NameOccupation { get; set; }

        [JsonPropertyName("level_occupation")]
        public string LevelOccupation { get; set; }
    }

    public class OccupationUpdateRequestValidator : AbstractValidator<OccupationUpdateRequest>
    {
        public OccupationUpdateRequestValidator()
        {
            RuleFor(x => x.Id.ToString())
                .NotEmpty()
                    .WithMessage("Id is required")
                .NotNull()
                    .WithMessage("Id is required")
                .Matches("[0-9]")
                    .WithMessage("Id must have only numbers");

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
