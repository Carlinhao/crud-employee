using FluentValidation;

namespace employers.domain.Entities.Occupation
{
    public class OccupationEntity : EntityBase
    {
        public string NameOccupation { get; set; }
        public string LevelOccupation { get; set; }
    }

    public class OccupationEntityValidator : AbstractValidator<OccupationEntity>
    {
        public OccupationEntityValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Fild id is empty")
                .NotNull()
                .WithMessage("Fild id is null");

            RuleFor(x => x.NameOccupation)
                .NotEmpty()
                .WithMessage("Fild Name Occupation is empty")
                .NotNull()
                .WithMessage("Fild Name ccupation is null");

            RuleFor(x => x.LevelOccupation)
                .NotEmpty()
                .WithMessage("Fild Level Occupation is empty")
                .NotNull()
                .WithMessage("Fild Level Occupation is null");
        }
    }
}
