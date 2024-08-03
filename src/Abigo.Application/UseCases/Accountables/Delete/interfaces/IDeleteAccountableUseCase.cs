namespace Abigo.Application.UseCases.Accountables.Delete.interfaces
{
    public interface IDeleteAccountableUseCase
    {
        Task Execute(string id, string token); 
    }
}
