using Trovantenato.Application.Services.Immigrant.Queries.GetImmigrants;

namespace Trovantenato.Application.Services.Immigrant.Queries.GetImmigrantsBySurname
{
    public class ImmigrantVm
    {
        public IList<ImmigrantDto> Immigrants { get; set; } = new List<ImmigrantDto>();
    }
}
