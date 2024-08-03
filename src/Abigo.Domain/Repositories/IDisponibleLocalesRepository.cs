using Abigo.Domain.Entities;
using Abigo.Domain.Enums;

namespace Abigo.Domain.Repositories
{
    public interface IDisponibleLocalesRepository
    {
        public Task<bool> CreateNewDisponibleLocale(DisponibleLocalesEntity localeData);
        public Task<List<DisponibleLocalesEntity>> FindAllDisponibleLocales();

        public Task<List<DisponibleLocalesEntity>> FindLocalesByCategory(LocalesCategories category);

        public Task<DisponibleLocalesEntity> SearchDisponibleLocale(string id);

        public Task<List<DisponibleLocalesEntity>> SearchDisponibleLocalesByAccount(string accountId);

        public Task<bool> EditLocale(DisponibleLocalesEntity localeData, string localeId);
        public Task<bool> DeleteLocale(string localeId);
    }
}
