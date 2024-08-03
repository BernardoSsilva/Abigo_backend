using Abigo.Communication.Responses.DisponibleLocales;

namespace Abigo.Application.UseCases.AvailableLocales.get.Interfaces
{
    public interface IFIndAllAvailableLocalesUseCase
    {
        Task<MultipleLocalesResponseJson> Execute();
    }
}
