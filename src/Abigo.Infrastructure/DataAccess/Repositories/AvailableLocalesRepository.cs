using Abigo.Domain.Entities;
using Abigo.Domain.Enums;
using Abigo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Abigo.Infrastructure.DataAccess.Repositories
{
    internal class AvailableLocalesRepository : IAvailableLocalesRepository
    {

        private readonly AbigoDbAccess _dbAccess;
        public AvailableLocalesRepository(AbigoDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }
        public async Task<bool> CreateNewDisponibleLocale(AvailableLocalesEntity localeData)
        {
            await _dbAccess.AvailableLocales.AddAsync(localeData);
            return true;
        }

        public async Task<bool> DeleteLocale(string localeId)
        {
            var localeToDelete = await _dbAccess.AvailableLocales.FirstOrDefaultAsync(locale => locale.Id == localeId);
            if (localeToDelete is null)
            {
                return false;
            }
            _dbAccess.AvailableLocales.Remove(localeToDelete);
            return true;
        }

        public async Task<bool> EditLocale(AvailableLocalesEntity localeData)
        {
            _dbAccess.AvailableLocales.Update(localeData);
            return true;
        }

        public async Task<List<AvailableLocalesEntity>> FindAllAvailableLocales()
        {
            var response = await _dbAccess.AvailableLocales.AsNoTracking().ToListAsync();
            return response;
        }

        public async Task<List<AvailableLocalesEntity>> FindLocalesByCategory(LocalesCategories category)
        {
            var response = await _dbAccess.AvailableLocales.Where(locale => locale.Category == category).ToListAsync();
            return response;
        }

        public async Task<AvailableLocalesEntity?> SearchDisponibleLocale(string id)
        {
            var response = await _dbAccess.AvailableLocales.FirstOrDefaultAsync(locale => locale.Id == id);
            return response;
        }

        public async Task<List<AvailableLocalesEntity>> SearchAvailableLocalesByAccount(string accountId)
        {
            var response = await _dbAccess.AvailableLocales.Where(locale => locale.AccountId == accountId).ToListAsync();
            return response;
        }
    }
}
