using Abigo.Domain.Entities;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;

namespace Abigo.Tests.Helppers
{
    public class InMemoryAccountablesRepository : IAccountablesRepository
    {
        private readonly List<AccountableEntity> _accountables;

        public InMemoryAccountablesRepository(List<AccountableEntity> accountables)
        {
            _accountables = accountables ?? new List<AccountableEntity>();
        }

        public Task<bool> CreateNewAccount(AccountableEntity accountable)
        {
            try
            {
                _accountables.Add(accountable);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteAccountable(string accountableId)
        {
            var entityToDelete = _accountables.FirstOrDefault(a => a.Id == accountableId);
            if (entityToDelete != null)
            {
                _accountables.Remove(entityToDelete);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<List<AccountableEntity>> FindAllAccountables()
        {
            return Task.FromResult(_accountables.ToList());
        }

        public Task<AccountableEntity?> SearchAccountable(string id)
        {
            var entity = _accountables.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(entity);
        }

        public void UpdateAccountable(AccountableEntity accountable)
        {
            var entityToUpdate = _accountables.FirstOrDefault(a => a.Id == accountable.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = accountable.Name;
                // Atualize outros campos conforme necessário
            }
        }
    }
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public Task Commit()
        {
            // No-op for in-memory implementation
            return Task.CompletedTask;
        }
    }
 }