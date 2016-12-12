using FluentValidation;
using Api.Architecture.Domain.Entities.Messages;
using Api.Architecture.Infra.Data.Models;

namespace Api.Architecture.Domain.Entities.Validation
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage(ValidationMessage.Validate.FirstName)
                .Length(2, 50).WithMessage(ValidationMessage.Length.FirstName, 2, 50);
        }
    }
}
