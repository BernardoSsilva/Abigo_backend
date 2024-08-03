using Abigo.Domain.Entities;

namespace Abigo.Domain.Repositories
{
    public interface AccountablesRepository
    {
        public Task<bool> CreateNewAccount(AccountableEntity accountable);

        public Task<List<AccountableEntity>> FindAllAccountables();

        public Task<AccountableEntity> SearchAccountable(string id);

        public Task<bool> UpdateAccountable(AccountableEntity accountable, string id);
        public Task<bool> DeleteAccountable(string id);
    }
}
