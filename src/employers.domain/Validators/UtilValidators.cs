using FluentValidation;
using FluentValidation.Results;

namespace employers.domain.Validators
{
    public static class UtilValidators
    {
        public static ValidationResult ValidadorResult<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE> where TE : class
        {
            return validacao.Validate(entidade);
        }
    }
}
