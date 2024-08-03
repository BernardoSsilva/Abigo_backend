using Abigo.Domain.Entities;
using Abigo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Abigo.Infrastructure.DataAccess.Repositories
{
    internal class AccountablesRepository : IAccountablesRepository
    {

        private readonly AbigoDbAccess _dbAccess;


        public AccountablesRepository(AbigoDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }
        public async Task<bool> CreateNewAccount(AccountableEntity accountable)
        {
            try
            {
                await _dbAccess.AddAsync(accountable);
                return true;

            } 
            catch
            {
                return false;
            }

        }

        public async Task<bool> DeleteAccountable(string accountableId)
        {
            var entityToDelete = await _dbAccess.Accountables.FirstOrDefaultAsync(accountable => accountable.Id == accountableId);
            if(entityToDelete is null)
            {
                return false;
            }
            _dbAccess.Accountables.Remove(entityToDelete);
            return true;
        }

        public async Task<List<AccountableEntity>> FindAllAccountables()
        {
            var response = await _dbAccess.Accountables.AsNoTracking().ToListAsync();

            return response;
        }

        public async Task<AccountableEntity?> SearchAccountable(string id)
        {
            var response = await _dbAccess.Accountables.FirstOrDefaultAsync(account => account.Id == id);
           
            return response;
        }

        public async Task<bool> UpdateAccountable(AccountableEntity accountable)
        {
        
            _dbAccess.Accountables.Update(accountable);
            return true;
        }
    }
}
