using Microsoft.AspNetCore.Mvc;
using Trovantenato.Application.Services.Contacts.Command.CreateContact;

namespace Trovantenato.Web.Api.Controllers
{
    public class ContactController : ApiControllerBase
    {
        //[Authorize("All")]
        [HttpPost]
        public async Task<ActionResult<bool>> Post(CreateContactCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
