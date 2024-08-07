﻿using Abigo.Domain.Entities;
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
        public async Task CreateNewDisponibleLocale(AvailableLocalesEntity localeData)
        {
            await _dbAccess.AvailableLocales.AddAsync(localeData);
        }

        public async Task DeleteLocale(string localeId)
        {
            var localeToDelete = await _dbAccess.AvailableLocales.FirstOrDefaultAsync(locale => locale.Id == localeId);
        
            _dbAccess.AvailableLocales.Remove(localeToDelete);
        }

        public  void EditLocale(AvailableLocalesEntity localeData)
        {
            _dbAccess.AvailableLocales.Update(localeData);
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

        public async Task<AvailableLocalesEntity?> SearchAvailableLocaleByName(string localeName)
        {
            var response = await _dbAccess.AvailableLocales.FirstOrDefaultAsync(locale => locale.LocaleName == localeName);
            return response;
        }

        public async Task<List<AvailableLocalesEntity>> SearchAvailableLocaleByCity(string localeCity)
        {
            var response = await _dbAccess.AvailableLocales.Where(locale => locale.City == localeCity).ToListAsync();
            return response;
        }

        public async Task<List<AvailableLocalesEntity>> SearchAvailableLocalesByNeighborHood(string neighborhoodName)
        {
            var response = await _dbAccess.AvailableLocales.Where(locale => locale.NeighboorHood == neighborhoodName).ToListAsync();
            return response;
        }
    }
}
