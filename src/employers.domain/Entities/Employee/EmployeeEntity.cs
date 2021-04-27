using FluentValidation;

namespace employers.domain.Entities.Employee
{
    public class EmployeeEntity : EntityBase
    {
        public string Name { get; set; }
        public int IdDepartament { get; set; }
        public int IdOccupation { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
    }

    public class EmployerEntityValidator : AbstractValidator<EmployeeEntity>
    {
        public EmployerEntityValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is empty")
                .NotNull()
                .WithMessage("Id is null");

            RuleFor(x => x.IdDepartament)
                .NotEmpty()
                .WithMessage("Id Department is empty")
                .NotNull()
                .WithMessage("Id Department is null");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is empty")
                .NotNull()
                .WithMessage("Name is null");

            RuleFor(x => x.Gender)
                .NotEmpty()
                .WithMessage("Gender is empty")
                .NotNull()
                .WithMessage("Gender is null");
        }
    }
}
