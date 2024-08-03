using Abigo.Domain.Entities;
using Abigo.Domain.Enums;

namespace Abigo.Domain.Repositories
{
    public interface IDisponibleLocalesRepository
    {
         Task<bool> CreateNewDisponibleLocale(DisponibleLocalesEntity localeData);
         Task<List<DisponibleLocalesEntity>> FindAllDisponibleLocales();

         Task<List<DisponibleLocalesEntity>> FindLocalesByCategory(LocalesCategories category);

         Task<DisponibleLocalesEntity?> SearchDisponibleLocale(string id);

         Task<List<DisponibleLocalesEntity>> SearchDisponibleLocalesByAccount(string accountId);

         Task<bool> EditLocale(DisponibleLocalesEntity localeData);
         Task<bool> DeleteLocale(string localeId);
    }
}
