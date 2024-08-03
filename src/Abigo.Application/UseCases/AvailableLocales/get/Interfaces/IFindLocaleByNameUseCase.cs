using Abigo.Communication.Responses.AvailableLocales;

namespace Abigo.Application.UseCases.AvailableLocales.get.Interfaces
{
    public interface IFindLocaleByNameUseCase
    {
        Task<AvailableLocalesDetailedResponseJson> Execute(string name);
    }
}
