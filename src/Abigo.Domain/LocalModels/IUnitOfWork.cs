namespace Abigo.Domain.Models
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
