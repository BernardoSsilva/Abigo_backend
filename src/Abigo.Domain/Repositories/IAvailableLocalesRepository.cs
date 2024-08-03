using Abigo.Domain.Entities;
using Abigo.Domain.Enums;

namespace Abigo.Domain.Repositories
{
    public interface IAvailableLocalesRepository
    {
        Task CreateNewDisponibleLocale(AvailableLocalesEntity localeData);
        Task<List<AvailableLocalesEntity>> FindAllAvailableLocales();

        Task<List<AvailableLocalesEntity>> FindLocalesByCategory(LocalesCategories category);

        Task<AvailableLocalesEntity?> SearchDisponibleLocale(string id);

        Task<AvailableLocalesEntity?> SearchAvailableLocaleByName(string localeName);
        Task<List<AvailableLocalesEntity>> SearchAvailableLocaleByCity(string localeCity);


        Task<List<AvailableLocalesEntity>> SearchAvailableLocalesByAccount(string accountId);

        Task EditLocale(AvailableLocalesEntity localeData);
        Task DeleteLocale(string localeId);
    }
}
