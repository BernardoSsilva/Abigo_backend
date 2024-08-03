using Abigo.Communication.Responses.DisponibleLocales;

namespace Abigo.Application.UseCases.AvailableLocales.get.Interfaces
{
    public interface IFindLocalesByAccountUseCase
    {
        Task<MultipleLocalesResponseJson> Execute(string accountId);
    }
}
