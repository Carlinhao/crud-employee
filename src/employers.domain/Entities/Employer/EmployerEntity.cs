using FluentValidation;

namespace employers.domain.Entities.Employer
{
    public class EmployerEntity : EntityBase
    {
        public string Name { get; set; }
        public int IdDepartament { get; set; }
    }

    public class EmployerUpdateValidator : AbstractValidator<EmployerEntity>
    {
        public EmployerUpdateValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id não informado")
                .NotNull()
                .WithMessage("Id não informado");

            RuleFor(x => x.IdDepartament)
                .NotEmpty()
                .WithMessage("Id do Departamento não informado")
                .NotNull()
                .WithMessage("Id do Departamento não informado");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Employer não informado")
                .NotNull()
                .WithMessage("Employer não informado");
        }
    }
}
