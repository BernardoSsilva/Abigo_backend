using Abigo.Communication.Requests;

namespace Abigo.Application.UseCases.Accountables.Put.Interfaces
{
    public interface IUpdateAccountableUseCase
    {
        Task Execute(AccountableRequestJson request, string id, string token);
    }
}
