namespace Abigo.Application.UseCases.AvailableLocales.Delete.Interfaces
{
    public interface IDeleteAvailableLocaleUseCase
    {
        Task Execute(string localeId, string token);
    }
}
