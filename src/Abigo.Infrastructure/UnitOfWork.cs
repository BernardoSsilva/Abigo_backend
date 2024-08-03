using Abigo.Domain.Models;

namespace Abigo.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AbigoDbAccess _dbAccess;

        public UnitOfWork(AbigoDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }
        public async Task Commit()
        {
            await _dbAccess.SaveChangesAsync();
        }
    }
}
