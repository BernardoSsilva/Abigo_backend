using Abigo.Communication.Responses.DisponibleLocales;
using Abigo.Domain.Enums;

namespace Abigo.Application.UseCases.AvailableLocales.get.Interfaces
{
    public interface IFindAllLocalesByNeighborhoodUseCase
    {
        Task<MultipleLocalesResponseJson> Execute(string neighborhoodName);
    }
}
