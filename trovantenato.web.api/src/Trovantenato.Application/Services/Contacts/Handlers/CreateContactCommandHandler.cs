using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Trovantenato.Application.Common.Functions;
using Trovantenato.Application.Services.Contacts.Command.CreateContact;
using Trovantenato.Domain.Entities;
using Trovantenato.Domain.Interfaces.Repository;
using Trovantenato.Infrastructure.Configurations;

namespace Trovantenato.Application.Services.Contacts.Handlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly EmailSettings _emailSettings;
        private readonly IContactsRepository _contactsRepository;

        public CreateContactCommandHandler(
            IMapper mapper
            , IOptions<EmailSettings> options
            , IContactsRepository contactsRepository)
        {
            _mapper = mapper;
            _emailSettings = options.Value;
            _contactsRepository = contactsRepository;
        }

        public async Task<bool> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new ContactsEntity
            {
                Name = request.Name,
                Email = request.Email,
                Subject = request.Subject,
                Message = request.Message
            };

            await _contactsRepository.InsertAsync(contact, cancellationToken);

            var result = CommonFunctions.SendContactEmail(request, _emailSettings);

            return result;
        }
    }
}
