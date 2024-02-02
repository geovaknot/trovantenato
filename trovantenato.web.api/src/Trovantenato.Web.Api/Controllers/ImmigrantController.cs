using Microsoft.AspNetCore.Mvc;
using Trovantenato.Application.Services.Immigrant.Command.CreateImmigrantsByFileUpload;
using Trovantenato.Application.Services.Immigrant.Command.GetImmigrantBySurname;
using Trovantenato.Application.Services.Immigrant.Queries.CreateImmigrantsByFileUpload;
using Trovantenato.Application.Services.Immigrant.Queries.GetImmigrantsBySurname;

namespace Trovantenato.Web.Api.Controllers
{
    public class ImmigrantController : ApiControllerBase
    {
        [HttpGet("{surname}")]
        public async Task<ActionResult<ImmigrantVm>> Get(string surname)
        {
            return await Mediator.Send(new GetImmigrantsBySurnameCommand() { Surname = surname });
        }

        [HttpPost("Upload/Csv")]
        public async Task<ActionResult<CreateImmigrantsByFileUploadDto>> Upload([FromForm] CreateImmigrantsByFileUploadCommand request)
        {
            var token = "eyJhbGciOiJSUzM4NCIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRyb3ZhbnRlbmF0byBBZG1pbiBVcGxvYWQiLCJhZG1pbiI6dHJ1ZSwiaWF0IjoxNTE2MjM5MDIyfQ.oZ2ZN63_hD6j0cul3gQGMjx_VyYA8TRewkYDfy8qMXECpC817erdoBIq6KHIgtzWeTBHrIkxhcmTGALwEAOGDblxWCL-ofx8AY2QQBAezRth6FW2QTei3jeoMl0xEPk3u8DvcyNNL4X7sfPwB0MmUBHFy5xlo7RmLi3a6n3L_ceG-4ndsvZRPs0tqgrclRukxax1b9SUixALtZhh7L-Cg_V3q4Nr7sp_3Prx7m73WrfOJ4zUs32_WraBbmtAoJJiLF1AeWEf5N6HtSeZ0BMp2Kfn4s1zEc242caUjXg9SciO8aBSi5NzCwqrS_ZTFUJRXSenjjVqrC3NEzgzVGSKsQ";

            if (request.Token != token) return Unauthorized();

            return await Mediator.Send(request);
        }
    }
}
