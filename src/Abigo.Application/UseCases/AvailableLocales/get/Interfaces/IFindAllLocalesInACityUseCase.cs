using Abigo.Communication.Responses.DisponibleLocales;

namespace Abigo.Application.UseCases.AvailableLocales.get.Interfaces
{
    public interface IFindAllLocalesInACityUseCase
    {
        Task<MultipleLocalesResponseJson> Exectue(string cityName);
    }
}
