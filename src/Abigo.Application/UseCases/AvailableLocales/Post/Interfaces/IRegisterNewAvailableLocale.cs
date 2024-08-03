using Abigo.Communication.Requests;
using Abigo.Communication.Responses.AvailableLocales;

namespace Abigo.Application.UseCases.AvailableLocales.Post.Interfaces
{
    public interface IRegisterNewAvailableLocale
    {
        Task<AvailableLocalesShortResponseJson> Execute(AvailableLocalesRequestJson request, string token);
    }
}
