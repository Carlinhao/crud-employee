using FluentValidation;

namespace employers.domain.Entities
{
    public class DepartmentEntity : EntityBase
    {        
        public string Name { get; set; }
        public int Manager { get; set; }
        public string Description { get; set; }
    }

    public class DepartmentEntityValidator : AbstractValidator<DepartmentEntity>
    {
        public DepartmentEntityValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Fild Name is empty")
                .NotNull()
                .WithMessage("Fild Name is null");

            RuleFor(x => x.Manager)
                .NotEmpty()
                .WithMessage("Fild Manager is empty")
                .NotNull()
                .WithMessage("Fild Manager is null");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Fild Description is empty")
                .NotNull()
                .WithMessage("Fild Description is null");
        }
    }
}
