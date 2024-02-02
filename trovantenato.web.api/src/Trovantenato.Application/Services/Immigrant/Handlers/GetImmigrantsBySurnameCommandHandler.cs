using AutoMapper;
using MediatR;
using Trovantenato.Application.Common.CustomAttibutes;
using Trovantenato.Application.Services.Immigrant.Command.GetImmigrantBySurname;
using Trovantenato.Application.Services.Immigrant.Queries.GetImmigrants;
using Trovantenato.Application.Services.Immigrant.Queries.GetImmigrantsBySurname;
using Trovantenato.Domain.Interfaces.Repository;

namespace Trovantenato.Application.Services.Immigrant.Handlers
{
    public class GetImmigrantsBySurnameCommandHandler : IRequestHandler<GetImmigrantsBySurnameCommand, ImmigrantVm>
    {
        private readonly IMapper _mapper;
        private readonly IImmigrantsRepository _immigrantsRepository;

        public GetImmigrantsBySurnameCommandHandler(
            IMapper mapper
            , IImmigrantsRepository immigrantsRepository)
        {
            _mapper = mapper;
            _immigrantsRepository = immigrantsRepository;
        }

        public async Task<ImmigrantVm> Handle(GetImmigrantsBySurnameCommand request, CancellationToken cancellationToken)
        {
            var immigrants = await _immigrantsRepository.SelectAllAsync(i => i.Surname.Contains(request.Surname));
            var data = new List<ImmigrantDto>();
            var result = new ImmigrantVm();

            foreach (var immigrant in immigrants)
            {
                data.Add(new ImmigrantDto
                {
                    Id = immigrant.Id,
                    Surname = ConfidentialAttribute.GetPropertyConfidential(nameof(ImmigrantDto.Surname)) ?? immigrant.Surname,
                    Source = ConfidentialAttribute.GetPropertyConfidential(nameof(ImmigrantDto.Source)) ?? immigrant.Source,
                    Province = ConfidentialAttribute.GetPropertyConfidential(nameof(ImmigrantDto.Province)) ?? immigrant.Province,
                    Comune = ConfidentialAttribute.GetPropertyConfidential(nameof(ImmigrantDto.Comune)) ?? immigrant.Comune,
                    Birthday = immigrant.Birthday,
                    Paternity = ConfidentialAttribute.GetPropertyConfidential(nameof(ImmigrantDto.Paternity)) ?? immigrant.Paternity,
                    Spouse = ConfidentialAttribute.GetPropertyConfidential(nameof(ImmigrantDto.Spouse)) ?? immigrant.Spouse,
                    MarriageDate = immigrant.MarriageDate,
                    Marriage = ConfidentialAttribute.GetPropertyConfidential(nameof(ImmigrantDto.Marriage)) ?? immigrant.Marriage,
                    ArrivalBrazilLocation = ConfidentialAttribute.GetPropertyConfidential(nameof(ImmigrantDto.ArrivalBrazilLocation)) ?? immigrant.ArrivalBrazilLocation,
                    ArrivalBrazilDate = immigrant.ArrivalBrazilDate
                });
            }

            result.Immigrants = data;

            return result;
        }
    }
}
