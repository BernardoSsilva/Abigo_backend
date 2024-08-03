using Abigo.Communication.Responses.DisponibleLocales;
using Abigo.Domain.Enums;

namespace Abigo.Application.UseCases.AvailableLocales.get.Interfaces
{
    public interface IFindAllLocalesByCategoryUseCase
    {
        Task<MultipleLocalesResponseJson> Execute(LocalesCategories category);
    }
}
