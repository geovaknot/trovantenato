using MediatR;
using Microsoft.AspNetCore.Http;
using Trovantenato.Application.Services.Immigrant.Queries.CreateImmigrantsByFileUpload;

namespace Trovantenato.Application.Services.Immigrant.Command.CreateImmigrantsByFileUpload
{
    public class CreateImmigrantsByFileUploadCommand : IRequest<CreateImmigrantsByFileUploadDto>
    {
        public string Token { get; set; }
        public IFormFile CsvFile { get; set; }
    }
}
