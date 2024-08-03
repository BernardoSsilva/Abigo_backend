using Abigo.Domain.Entities;
using Abigo.Domain.Enums;

namespace Abigo.Domain.Repositories
{
    public interface IAvailableLocalesRepository
    {
        Task<bool> CreateNewDisponibleLocale(AvailableLocalesEntity localeData);
        Task<List<AvailableLocalesEntity>> FindAllAvailableLocales();

        Task<List<AvailableLocalesEntity>> FindLocalesByCategory(LocalesCategories category);

        Task<AvailableLocalesEntity?> SearchDisponibleLocale(string id);

        Task<List<AvailableLocalesEntity>> SearchAvailableLocalesByAccount(string accountId);

        Task<bool> EditLocale(AvailableLocalesEntity localeData);
        Task<bool> DeleteLocale(string localeId);
    }
}
