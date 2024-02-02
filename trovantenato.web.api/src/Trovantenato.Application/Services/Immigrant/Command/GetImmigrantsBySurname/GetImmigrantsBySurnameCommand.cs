using MediatR;
using Trovantenato.Application.Services.Immigrant.Queries.GetImmigrantsBySurname;

namespace Trovantenato.Application.Services.Immigrant.Command.GetImmigrantBySurname
{
    public class GetImmigrantsBySurnameCommand : IRequest<ImmigrantVm>
    {
        public string Surname { get; set; }
    }
}
