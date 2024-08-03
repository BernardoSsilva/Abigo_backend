using Abigo.Communication.Responses.AvailableLocales;

namespace Abigo.Application.UseCases.AvailableLocales.get.Interfaces
{
    public interface IFindLocaleByIdUseCase
    {
        Task<AvailableLocalesDetailedResponseJson> Execute(string id);
    }
}
