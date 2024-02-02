using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using System.Globalization;
using Trovantenato.Application.Services.Immigrant.Command.CreateImmigrantsByFileUpload;
using Trovantenato.Application.Services.Immigrant.Queries.CreateImmigrantsByFileUpload;
using Trovantenato.Application.Services.Immigrant.Queries.GetImmigrants;
using Trovantenato.Domain.Entities;
using Trovantenato.Domain.Interfaces.Repository;

namespace Trovantenato.Application.Services.Immigrant.Handlers
{
    public class CreateImmigrantsByFileUploadCommandHandler : IRequestHandler<CreateImmigrantsByFileUploadCommand, CreateImmigrantsByFileUploadDto>
    {
        private readonly IMapper _mapper;
        private readonly IImmigrantsRepository _immigrantsRepository;

        public CreateImmigrantsByFileUploadCommandHandler(
            IMapper mapper
            , IImmigrantsRepository immigrantsRepository)
        {
            _mapper = mapper;
            _immigrantsRepository = immigrantsRepository;
        }

        public async Task<CreateImmigrantsByFileUploadDto> Handle(CreateImmigrantsByFileUploadCommand request, CancellationToken cancellationToken)
        {
            var records = new List<ImmigrantFileDto>();
            var data = new List<ImmigrantsEntity>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(request.CsvFile.OpenReadStream()))
            using (var csv = new CsvReader(reader, config))
            {
                records = csv.GetRecords<ImmigrantFileDto>().ToList();
            }

            foreach (var record in records)
            {
                data.Add(new ImmigrantsEntity
                {
                    Surname = record.Surname,
                    Source = record.Source,
                    Province = record.Province,
                    Comune = record.Comune,
                    Birthday = record.Birthday,
                    Paternity = record.Paternity,
                    Spouse = record.Spouse,
                    MarriageDate = record.MarriageDate,
                    Marriage = record.Marriage,
                    ArrivalBrazilLocation = record.ArrivalBrazilLocation,
                    ArrivalBrazilDate = record.ArrivalBrazilDate
                });
            }

            await _immigrantsRepository.InsertRangeAsync(data);

            return new CreateImmigrantsByFileUploadDto { TotalRecordsSaved = records.Count };
        }
    }
}
