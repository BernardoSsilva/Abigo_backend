using Abigo.Communication.Requests;

namespace Abigo.Application.UseCases.AvailableLocales.Put.Interfaces
{
    public interface IUpdateAvailableLocaleUseCase
    {
        Task Execute(string localeId, string token, AvailableLocalesRequestJson request);
    }
}
