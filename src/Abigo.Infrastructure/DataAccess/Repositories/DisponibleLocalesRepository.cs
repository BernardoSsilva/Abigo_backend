using Abigo.Domain.Entities;
using Abigo.Domain.Enums;
using Abigo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Abigo.Infrastructure.DataAccess.Repositories
{
    internal class DisponibleLocalesRepository : IDisponibleLocalesRepository
    {

        private readonly AbigoDbAccess _dbAccess;
        public DisponibleLocalesRepository(AbigoDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }
        public async Task<bool> CreateNewDisponibleLocale(DisponibleLocalesEntity localeData)
        {
            await _dbAccess.DisponibleLocales.AddAsync(localeData);
            return true;
        }

        public async Task<bool> DeleteLocale(string localeId)
        {
            var localeToDelete = await _dbAccess.DisponibleLocales.FirstOrDefaultAsync(locale => locale.Id == localeId);
            if (localeToDelete is null)
            {
                return false;
            }
            _dbAccess.DisponibleLocales.Remove(localeToDelete);
            return true;
        }

        public async Task<bool> EditLocale(DisponibleLocalesEntity localeData)
        {
            _dbAccess.DisponibleLocales.Update(localeData);
            return true;
        }

        public async Task<List<DisponibleLocalesEntity>> FindAllDisponibleLocales()
        {
            var response = await _dbAccess.DisponibleLocales.AsNoTracking().ToListAsync();
            return response;
        }

        public async Task<List<DisponibleLocalesEntity>> FindLocalesByCategory(LocalesCategories category)
        {
            var response = await _dbAccess.DisponibleLocales.Where(locale => locale.Category == category).ToListAsync();
            return response;
        }

        public async Task<DisponibleLocalesEntity?> SearchDisponibleLocale(string id)
        {
            var response = await _dbAccess.DisponibleLocales.FirstOrDefaultAsync(locale => locale.Id == id);
            return response;
        }

        public async Task<List<DisponibleLocalesEntity>> SearchDisponibleLocalesByAccount(string accountId)
        {
            var response = await _dbAccess.DisponibleLocales.Where(locale => locale.AccountId == accountId).ToListAsync();
            return response;
        }
    }
}
