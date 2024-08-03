using Abigo.Communication.Requests;
using Abigo.Communication.Responses.Accountable;

namespace Abigo.Application.UseCases.Accountables.Put.Interfaces
{
    public interface IUpdateAccountableUseCase
    {
        Task<AccountableDetailedResponse> Execute(AccountableRequestJson request, string token);
    }
}
