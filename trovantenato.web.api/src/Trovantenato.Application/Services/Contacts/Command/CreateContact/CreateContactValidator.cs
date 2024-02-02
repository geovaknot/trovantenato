using FluentValidation;

namespace Trovantenato.Application.Services.Contacts.Command.CreateContact
{
    public class CreateContactValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactValidator()
        {
            RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Campo NOME é obrigatório.");

            RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Campo E-MAIL é obrigatório.");

            RuleFor(v => v.Subject)
            .NotEmpty().WithMessage("Campo ASSUNTO é obrigatório.");

            RuleFor(v => v.Message)
            .NotEmpty().WithMessage("Campo MENSAGEM é obrigatório.");
        }
    }
}
