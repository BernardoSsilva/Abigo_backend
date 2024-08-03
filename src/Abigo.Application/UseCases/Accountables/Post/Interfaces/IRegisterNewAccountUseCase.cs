using Abigo.Communication.Requests;
using Abigo.Communication.Responses.Accountable;

namespace Abigo.Application.UseCases.Accountables.Post.Interfaces
{
    public interface IRegisterNewAccountUseCase
    {
        Task<AccountableShortResponseJson> Execute(AccountableRequestJson request);
    }
}
