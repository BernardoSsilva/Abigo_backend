using Abigo.Domain.Entities;

namespace Abigo.Domain.Repositories
{
    public interface IAccountablesRepository
    {
         Task<bool> CreateNewAccount(AccountableEntity accountable);

         Task<List<AccountableEntity>> FindAllAccountables();

         Task<AccountableEntity?> SearchAccountable(string id);

         void UpdateAccountable(AccountableEntity accountable);
         Task<bool> DeleteAccountable(string accountableId);
    }
}
