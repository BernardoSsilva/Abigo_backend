namespace Abigo.Application.UseCases.Accountables.Delete.interfaces
{
    public interface IDeleteAccountableUseCase
    {
        Task<bool> Execute(string token); 
    }
}
